using Framework.Scriban.Models;
using Scriban;

namespace Framework.Scriban;

public sealed class ScribanTemplateGenerator
{
    /// <summary>
    /// 根据指定的模板和数据库表信息生成渲染后的字符串结果。
    /// </summary>
    /// <remarks>模板语法需符合 Scriban 规范。方法不会对模板内容做语法校验，若模板有误将直接抛出异常。</remarks>
    /// <param name="template">用于渲染的模板字符串。不能为空或仅包含空白字符。</param>
    /// <param name="table">包含用于模板渲染的数据的数据库表对象。不能为空。</param>
    /// <returns>渲染后的字符串结果，内容基于模板和数据库表信息生成。</returns>
    /// <exception cref="ArgumentException">当 <paramref name="template"/> 为空或仅包含空白字符时抛出。</exception>
    /// <exception cref="InvalidOperationException">当模板解析失败时抛出，异常消息包含具体的解析错误信息。</exception>
    public string Generate(string template, DatabaseTable table)
    {
        if (string.IsNullOrWhiteSpace(template))
        {
            throw new ArgumentException("模板内容不能为空。", nameof(template));
        }

        ArgumentNullException.ThrowIfNull(table);

        var parsedTemplate = Template.Parse(template);
        if (parsedTemplate.HasErrors)
        {
            var errorMessage = string.Join(Environment.NewLine, parsedTemplate.Messages.Select(m => m.Message));
            throw new InvalidOperationException($"模板解析失败：{errorMessage}");
        }

        return parsedTemplate.Render(table, member => member.Name);
    }
}
