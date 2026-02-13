using Gestao.Cadastro.Digital.Worker.Auditoria.Models;
using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace Gestao.Cadastro.Digital.Worker.Auditoria.Utils;

public static class AuditoriaMapper
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _cache = new();

    public static string GerarHistorico(
        string entidade,
        TipoAcao acao,
        object? antes,
        object? depois)
    {
        var resultado = new Dictionary<string, object?>
        {
            ["Entidade"] = entidade,
            ["Acao"] = acao.ToString()
        };

        if (antes == null && depois == null)
            return JsonSerializer.Serialize(resultado, Indented());

        CompararObjetos(
            antes,
            depois,
            resultado,
            prefixo: string.Empty);

        return JsonSerializer.Serialize(resultado, Indented());
    }

    private static void CompararObjetos(
        object? antes,
        object? depois,
        Dictionary<string, object?> resultado,
        string prefixo)
    {
        if (antes == null && depois == null)
            return;

        var tipo = depois?.GetType() ?? antes!.GetType();

        if (EhTipoSimples(tipo))
        {
            if (!Equals(antes, depois))
            {
                resultado[prefixo.Trim('.')] =
                    $"De {Formatar(antes)} para {Formatar(depois)}";
            }
            return;
        }

        if (typeof(IEnumerable).IsAssignableFrom(tipo) && tipo != typeof(string))
        {
            CompararListas(
                antes as IEnumerable,
                depois as IEnumerable,
                resultado,
                prefixo);
            return;
        }

        var propriedades = _cache.GetOrAdd(tipo,
            t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));

        foreach (var prop in propriedades)
        {
            if (IgnorarPropriedade(prop))
                continue;

            var valorAntes = antes == null ? null : prop.GetValue(antes);
            var valorDepois = depois == null ? null : prop.GetValue(depois);

            var nome = string.IsNullOrEmpty(prefixo)
                ? prop.Name
                : $"{prefixo}.{prop.Name}";

            if (valorAntes == null && valorDepois == null)
                continue;

            if (EhTipoSimples(prop.PropertyType))
            {
                if (!Equals(valorAntes, valorDepois))
                {
                    resultado[nome] =
                        $"De {Formatar(valorAntes)} para {Formatar(valorDepois)}";
                }
            }
            else
            {
                CompararObjetos(
                    valorAntes,
                    valorDepois,
                    resultado,
                    nome);
            }
        }
    }

    private static void CompararListas(
        IEnumerable? antes,
        IEnumerable? depois,
        Dictionary<string, object?> resultado,
        string prefixo)
    {
        var listaAntes = antes?.Cast<object>().ToList() ?? new();
        var listaDepois = depois?.Cast<object>().ToList() ?? new();

        if (listaAntes.Count != listaDepois.Count)
        {
            resultado[prefixo.Trim('.')] =
                $"Lista alterada (Antes: {listaAntes.Count}, Depois: {listaDepois.Count})";
            return;
        }

        for (int i = 0; i < listaAntes.Count; i++)
        {
            CompararObjetos(
                listaAntes[i],
                listaDepois[i],
                resultado,
                $"{prefixo}[{i}]");
        }
    }

    private static bool EhTipoSimples(Type type)
    {
        return type.IsPrimitive
            || type.IsEnum
            || type == typeof(string)
            || type == typeof(DateTime)
            || type == typeof(decimal)
            || type == typeof(Guid);
    }

    private static bool IgnorarPropriedade(PropertyInfo prop)
    {
        return prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)
            || prop.GetCustomAttribute<ObsoleteAttribute>() != null;
    }

    private static string Formatar(object? valor)
    {
        if (valor == null)
            return "vazio";

        if (valor is DateTime dt)
            return dt.ToString("yyyy-MM-dd HH:mm:ss");

        if (valor.GetType().IsEnum)
        {
            var description = valor.GetType()
                .GetField(valor.ToString()!)?
                .GetCustomAttribute<DescriptionAttribute>();

            return description?.Description ?? valor.ToString()!;
        }

        return valor.ToString()!;
    }

    private static JsonSerializerOptions Indented()
        => new() { WriteIndented = true };
}
