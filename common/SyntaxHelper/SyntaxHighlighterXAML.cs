using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace syncfusion.demoscommon.wpf
{
    public class SyntaxHighlighterXAML
    {
        /// <summary>
        /// Colors the XAML.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        public static Paragraph FormatCode(string line)
        {
            line = Regex.Replace(line, "[ ]*=[ ]*", "=", RegexOptions.Multiline);
            XmlTokenizer tokenizer = new XmlTokenizer();
            XmlTokenizerMode mode = XmlTokenizerMode.OutsideElement;

            List<XmlToken> tokens = tokenizer.Tokenize(line, ref mode);
            List<string> tokenTexts = new List<string>(tokens.Count);
            List<Color> colors = new List<Color>(tokens.Count);
            int position = 0;
            foreach (XmlToken token in tokens)
            {
                string tokenText = line.Substring(position, token.Length);
                tokenTexts.Add(tokenText);
                Color color = XmlTokenizer.ColorForToken(token, tokenText);
                colors.Add(color);
                position += token.Length;
            }

            Paragraph p = new Paragraph();
            for (int i = 0; i < tokenTexts.Count; i++)
            {
                Run r = new Run(tokenTexts[i]) { FontFamily = new FontFamily("Segoe UI"), FontSize = 14 };
                r.Foreground = new SolidColorBrush(colors[i]);
                p.Inlines.Add(r);
            }
            return p;
        }
    }

    /// <summary>
    /// Used so you can restart the tokenizer for the next line of XML 
    /// </summary>
    enum XmlTokenizerMode
    {
        /// <summary>
        /// 
        /// </summary>
        InsideComment,
        /// <summary>
        /// 
        /// </summary>
        InsideProcessingInstruction,
        /// <summary>
        /// 
        /// </summary>
        AfterOpen,
        /// <summary>
        /// 
        /// </summary>
        AfterAttributeName,
        /// <summary>
        /// 
        /// </summary>
        AfterAttributeEquals,
        /// <summary>
        /// 
        /// </summary>
        InsideElement, // after element name, before attribute or />
        /// <summary>
        /// 
        /// </summary>
        OutsideElement,
        /// <summary>
        /// 
        /// </summary>
        InsideCData,
    }

    /// <summary>
    /// 
    /// </summary>
    struct XmlToken
    {
        public XmlTokenKind Kind;
        public short Length;
        public XmlToken(XmlTokenKind kind, int length)
        {
            Kind = kind;
            Length = (short)length;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    enum XmlTokenKind : short
    {
        /// <summary>
        /// 
        /// </summary>
        Open, // <
        /// <summary>
        /// 
        /// </summary>
        Close,//>
        /// <summary>
        /// 
        /// </summary>
        SelfClose,// />
        /// <summary>
        /// 
        /// </summary>
        OpenClose,// </
        /// <summary>
        /// 
        /// </summary>
        ElementName,
        /// <summary>
        /// 
        /// </summary>
        ElementWhitespace,//whitespace between attributes
        /// <summary>
        /// 
        /// </summary>
        AttributeName,
        /// <summary>
        /// 
        /// </summary>
        Equals, // inside attribute
        /// <summary>
        /// 
        /// </summary>
        AttributeValue, // attribute value
        /// <summary>
        /// 
        /// </summary>
        CommentBegin, // <!--
        /// <summary>
        /// 
        /// </summary>
        CommentText,
        /// <summary>
        /// 
        /// </summary>
        CommentEnd, // -->
        /// <summary>
        /// 
        /// </summary>
        Entity, // &gt;
        /// <summary>
        /// 
        /// </summary>
        OpenProcessingInstruction, // <?
        /// <summary>
        /// 
        /// </summary>
        CloseProcessingInstruction, // ?>
        /// <summary>
        /// 
        /// </summary>
        CDataBegin, // <![CDATA[
        /// <summary>
        /// 
        /// </summary>
        CDataEnd,// ]]>
        /// <summary>
        /// 
        /// </summary>
        TextContent,
        //WhitespaceContent, // text content that's whitespace.  Space is embedded inside
        /// <summary>
        /// 
        /// </summary>
        EOF // end of file
    }

    /// <summary>
    /// XML tokenizer, tokens are designed to match Visual Studio syntax highlighting 
    /// </summary>
    class XmlTokenizer
    {
        string input;
        int position = 0;
        XmlTokenizerMode mode = XmlTokenizerMode.OutsideElement;

        /// <summary>
        /// Tokenizes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static List<XmlToken> Tokenize(string input)
        {
            XmlTokenizerMode mode = XmlTokenizerMode.OutsideElement;
            XmlTokenizer tokenizer = new XmlTokenizer();
            return tokenizer.Tokenize(input, ref mode);
        }

        /// <summary>
        /// Tokenizes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="_mode">The _mode.</param>
        /// <returns></returns>
        public List<XmlToken> Tokenize(string input, ref XmlTokenizerMode _mode)
        {
            this.input = input;
            this.mode = _mode;
            this.position = 0;
            List<XmlToken> result = Tokenize();
            _mode = this.mode;
            return result;
        }

        /// <summary>
        /// Tokenizes this instance.
        /// </summary>
        /// <returns></returns>
        private List<XmlToken> Tokenize()
        {
            List<XmlToken> list = new List<XmlToken>();
            try
            {

                XmlToken token;
                do
                {
                    int previousPosition = position;
                    token = NextToken();
                    string tokenText = input.Substring(previousPosition, token.Length);
                    list.Add(token);
                } while (token.Kind != XmlTokenKind.EOF);

                List<string> strings = TokensToStrings(list, input);
            }
            catch (Exception) { }
            return list;
        }

        /// <summary>
        /// Tokenses to strings.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private List<string> TokensToStrings(List<XmlToken> list, string input)
        {
            List<string> output = new List<string>();
            int position = 0;
            foreach (XmlToken token in list)
            {
                output.Add(input.Substring(position, token.Length));
                position += token.Length;
            }
            return output;
        }

        /// <summary>
        /// Gets the remaining text.
        /// </summary>
        /// <value>The remaining text.</value>
        public string RemainingText
        {
            get { return input.Substring(position); }
        }

        /// <summary>
        /// Nexts the token.
        /// </summary>
        /// <returns></returns>
        private XmlToken NextToken()
        {
            if (position >= input.Length)
                return new XmlToken(XmlTokenKind.EOF, 0);

            XmlToken token;
            switch (mode)
            {
                case XmlTokenizerMode.AfterAttributeEquals:
                    token = TokenizeAttributeValue();
                    break;
                case XmlTokenizerMode.AfterAttributeName:
                    token = TokenizeSimple("=", XmlTokenKind.Equals, XmlTokenizerMode.AfterAttributeEquals);
                    break;
                case XmlTokenizerMode.AfterOpen:
                    token = TokenizeName(XmlTokenKind.ElementName, XmlTokenizerMode.InsideElement);
                    break;
                case XmlTokenizerMode.InsideCData:
                    token = TokenizeInsideCData();
                    break;
                case XmlTokenizerMode.InsideComment:
                    token = TokenizeInsideComment();
                    break;
                case XmlTokenizerMode.InsideElement:
                    token = TokenizeInsideElement();
                    break;
                case XmlTokenizerMode.InsideProcessingInstruction:
                    token = TokenizeInsideProcessingInstruction();
                    break;
                case XmlTokenizerMode.OutsideElement:
                    token = TokenizeOutsideElement();
                    break;
                default:
                    token = new XmlToken(XmlTokenKind.EOF, 0);
                    Debug.Fail("missing case");
                    break;
            }
            return token;
        }

        /// <summary>
        /// Determines whether [is name character] [the specified character].
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>
        /// 	<c>true</c> if [is name character] [the specified character]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNameCharacter(char character)
        {
            // XML rule: Letter | Digit | '.' | '-' | '_' | ':' | CombiningChar | Extender
            bool result = char.IsLetterOrDigit(character)
            || character == '.' | character == '-' | character == '_' | character == ':';
            return result;
        }

        private XmlToken TokenizeAttributeValue()
        {
            Debug.Assert(mode == XmlTokenizerMode.AfterAttributeEquals);
            int closePosition = input.IndexOf(input[position], position + 1);
            XmlToken token = new XmlToken(XmlTokenKind.AttributeValue, closePosition + 1 - position);
            position = closePosition + 1;
            mode = XmlTokenizerMode.InsideElement;
            return token;
        }

        /// <summary>
        /// Tokenizes the name.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="nextMode">The next mode.</param>
        /// <returns></returns>
        private XmlToken TokenizeName(XmlTokenKind kind, XmlTokenizerMode nextMode)
        {
            Debug.Assert(mode == XmlTokenizerMode.AfterOpen || mode == XmlTokenizerMode.InsideElement);
            int i;
            for (i = position; i < input.Length; i++)
            {
                if (!IsNameCharacter(input[i]))
                {
                    break;
                }
            }
            XmlToken token = new XmlToken(kind, i - position);
            mode = nextMode;
            position = i;
            return token;
        }

        /// <summary>
        /// Tokenizes the element whitespace.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeElementWhitespace()
        {
            int i;
            for (i = position; i < input.Length; i++)
            {
                if (!char.IsWhiteSpace(input[i]))
                {
                    break;
                }
            }
            XmlToken token = new XmlToken(XmlTokenKind.ElementWhitespace, i - position);
            position = i;
            return token;
        }

        /// <summary>
        /// Startses the with.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private bool StartsWith(string text)
        {
            if (position + text.Length > input.Length)
                return false;
            else
                return input.Substring(position, text.Length) == text;
        }

        /// <summary>
        /// Tokenizes the inside element.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeInsideElement()
        {
            if (char.IsWhiteSpace(input[position]))
                return TokenizeElementWhitespace();
            else if (StartsWith("/>"))
                return TokenizeSimple("/>", XmlTokenKind.SelfClose, XmlTokenizerMode.OutsideElement);
            else if (StartsWith(">"))
                return TokenizeSimple(">", XmlTokenKind.Close, XmlTokenizerMode.OutsideElement);
            else
            {
                return TokenizeName(XmlTokenKind.AttributeName, XmlTokenizerMode.AfterAttributeName);
            }
        }

        /// <summary>
        /// Tokenizes the text.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeText()
        {
            Debug.Assert(input[position] != '<');
            Debug.Assert(input[position] != '&');
            Debug.Assert(mode == XmlTokenizerMode.OutsideElement);
            int i;
            for (i = position; i < input.Length; i++)
            {
                if (input[i] == '<' || input[i] == '&')
                {
                    break;
                }
            }
            XmlToken token = new XmlToken(XmlTokenKind.TextContent, i - position);
            position = i;
            return token;
        }

        /// <summary>
        /// Tokenizes the outside element.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeOutsideElement()
        {
            Debug.Assert(mode == XmlTokenizerMode.OutsideElement);
            if (position >= input.Length)
                return new XmlToken(XmlTokenKind.EOF, 0);

            switch (input[position])
            {
                case '<':
                    return TokenizeOpen();
                case '&':
                    return TokenizeEntity();
                default:
                    return TokenizeText();
            }
        }

        /// <summary>
        /// Tokenizes the simple.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="nextMode">The next mode.</param>
        /// <returns></returns>
        private XmlToken TokenizeSimple(string text, XmlTokenKind kind, XmlTokenizerMode nextMode)
        {
            XmlToken token = new XmlToken(kind, text.Length);
            position += text.Length;
            mode = nextMode;
            return token;
        }

        /// <summary>
        /// Tokenizes the open.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeOpen()
        {
            Debug.Assert(input[position] == '<');
            if (StartsWith("<!--"))
            {
                return TokenizeSimple("<!--", XmlTokenKind.CommentBegin, XmlTokenizerMode.InsideComment);
            }
            else if (StartsWith("<![CDATA["))
            {
                return TokenizeSimple("<![CDATA[", XmlTokenKind.CDataBegin, XmlTokenizerMode.InsideCData);
            }
            else if (StartsWith("<?"))
            {
                return TokenizeSimple("<?", XmlTokenKind.OpenProcessingInstruction, XmlTokenizerMode.InsideProcessingInstruction);
            }
            else if (StartsWith("</"))
            {
                return TokenizeSimple("</", XmlTokenKind.OpenClose, XmlTokenizerMode.AfterOpen);
            }
            else
            {
                return TokenizeSimple("<", XmlTokenKind.Open, XmlTokenizerMode.AfterOpen);
            }
        }

        /// <summary>
        /// Tokenizes the entity.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeEntity()
        {
            Debug.Assert(mode == XmlTokenizerMode.OutsideElement);
            Debug.Assert(input[position] == '&');
            XmlToken token = new XmlToken(XmlTokenKind.Entity, input.IndexOf(';', position) - position);
            position += token.Length;
            return token;
        }

        /// <summary>
        /// Tokenizes the inside processing instruction.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeInsideProcessingInstruction()
        {
            Debug.Assert(mode == XmlTokenizerMode.InsideProcessingInstruction);
            int tokenend = input.IndexOf("?>", position);
            if (position == tokenend)
            {
                position += "?>".Length;
                mode = XmlTokenizerMode.OutsideElement;
                return new XmlToken(XmlTokenKind.CloseProcessingInstruction, "?>".Length);
            }
            else
            {
                XmlToken token = new XmlToken(XmlTokenKind.TextContent, tokenend - position);
                position = tokenend;
                return token;
            }
        }

        /// <summary>
        /// Tokenizes the inside C data.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeInsideCData()
        {
            Debug.Assert(mode == XmlTokenizerMode.InsideCData);
            int tokenend = input.IndexOf("]]>", position);
            if (position == tokenend)
            {
                position += "]]>".Length;
                mode = XmlTokenizerMode.OutsideElement;
                return new XmlToken(XmlTokenKind.CDataEnd, "]]>".Length);
            }
            else
            {
                XmlToken token = new XmlToken(XmlTokenKind.TextContent, tokenend - position);
                position = tokenend;
                return token;
            }
        }

        /// <summary>
        /// Tokenizes the inside comment.
        /// </summary>
        /// <returns></returns>
        private XmlToken TokenizeInsideComment()
        {
            Debug.Assert(mode == XmlTokenizerMode.InsideComment);
            int tokenend = input.IndexOf("-->", position);
            if (position == tokenend)
            {
                position += "-->".Length;
                mode = XmlTokenizerMode.OutsideElement;
                return new XmlToken(XmlTokenKind.CommentEnd, "-->".Length);
            }
            else
            {
                XmlToken token = new XmlToken(XmlTokenKind.CommentText, tokenend - position);
                position = tokenend;
                return token;
            }
        }

        /// <summary>
        /// Colors for token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="tokenText">The token text.</param>
        /// <returns></returns>
        public static Color ColorForToken(XmlToken token, string tokenText)
        {
            Color color = Color.FromRgb(0, 0, 0);
            switch (token.Kind)
            {
                case XmlTokenKind.Open:
                case XmlTokenKind.OpenClose:
                case XmlTokenKind.Close:
                case XmlTokenKind.SelfClose:
                case XmlTokenKind.CommentBegin:
                case XmlTokenKind.CommentEnd:
                case XmlTokenKind.CDataBegin:
                case XmlTokenKind.CDataEnd:
                case XmlTokenKind.Equals:
                case XmlTokenKind.OpenProcessingInstruction:
                case XmlTokenKind.CloseProcessingInstruction:
                case XmlTokenKind.AttributeValue:
                    color = Color.FromRgb(0, 0, 255);
                    break;
                case XmlTokenKind.ElementName:
                    color = Color.FromRgb(163, 21, 21);
                    break;
                case XmlTokenKind.TextContent:
                    color = Color.FromRgb(0, 0, 0);
                    break;
                case XmlTokenKind.AttributeName:
                case XmlTokenKind.Entity:
                    color = Color.FromRgb(255, 0, 0);
                    break;
                case XmlTokenKind.CommentText:
                    color = Color.FromRgb(0, 128, 0);
                    break;
            }
            if (token.Kind == XmlTokenKind.ElementWhitespace
                || (token.Kind == XmlTokenKind.TextContent && tokenText.Trim() == ""))
            {
            }
            return color;
        }
    }
}
