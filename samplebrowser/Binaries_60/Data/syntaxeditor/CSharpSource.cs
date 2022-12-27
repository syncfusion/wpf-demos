#region Copyright Syncfusion Inc. 2001 - 2022
//
//  Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

  class Tokenizer
  {
    private int iTest = 5 + 5 ;
    private char chTest = 'a';
    private Token _token;
    private string _tokenValue;
    private TextReader _reader;
    private string _read = "";

    public Token LastToken 
    {
      get 
      {
        return _token;
      }
    }

    public string LastTokenValue 
    {
      get 
      {
        return _tokenValue;
      }
    }

    public Tokenizer(TextReader reader) 
    {
      _reader = reader;
    }
    
    private void PutBack(char ch) 
    {
      if (_read.Length == 0) 
      {
        _read = new String(ch, 1);
      } 
      else 
      {
        _read = ch + _read;
      }
    }

    private int Peek() 
    {
      int l = _read.Length;
      if (l == 0) 
      {
        int ch = _reader.Peek();
        return ch;
      } 
      else 
      {
        return _read[0];
      };
    }

    private int ReadChar() 
    {
      if (_read == "") 
      {
        return _reader.Read();
      } 
      else 
      {
        int ch = _read[0];
        _read = _read.Substring(1);
        return ch;
      }
    }

    private bool SkipSpaces() 
    {
      int ch = Peek();
      while (ch == ' ' || ch == 10 || ch == 12 || ch == 13 || ch == 9) 
      {
        ReadChar();
        ch = Peek();
      }
      return true;
    }

    private bool Probe(string symbol) 
    {
      int l = symbol.Length;
      int missed = l - _read.Length;
      if (missed > 0) 
      {
        int ch = 0;
        System.Text.StringBuilder sb = new System.Text.StringBuilder(_read);
        while (missed > 0 && ch != -1) 
        {
          ch = _reader.Read();
          if (ch == -1) break;
          sb.Append((char)ch);
          missed--;
        }
        _read = sb.ToString();
      }
      if (_read.Length >= l && _read.Substring(0, l).ToLower() == symbol) 
      {
        if (_read.Length > l) 
        {
          _read = _read.Substring(l);
        } 
        else 
        { 
          _read = "";
        };
        return true;
      } 
      else 
      {
        return false;
      };
    }

    private bool ProbeString(ref string str)
    {
      int delimiterChar;
      delimiterChar = Peek();
      if (delimiterChar == '"' || delimiterChar == '\'') 
      {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        ReadChar();
        int ch = ReadChar();
        while (ch != delimiterChar && ch != -1) 
        {
          if (ch == '\\') 
          {
            ch = ReadChar();
          }
          sb.Append((char)ch);
          ch = ReadChar();
        }
        if (ch == -1) 
        {
          _read = delimiterChar + sb.ToString();
          return false;
        }
        str = sb.ToString();
        return true;
      } 
      else 
      {
        return false;
      }
    }

    private bool ProbeIdent(ref string str) 
    {
      int ch = Peek();
      if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 128 && ch <= 255) 
        || (ch > 255) || (ch == '\\') || ch == '%' || ch == '*' ) 
      {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(ch);
        if (ch == '\\') 
        {
          ReadChar();
          ch = Peek();
        }
        sb.Append((char)ch);
        ReadChar();
        ch = Peek();
        while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 128 && ch <= 255) || (ch >= '0' && ch <= '9') 
          || ch == '-' || ch == '_' || ch == '%' || ch == '*' || ch == '\\') 
        {
          if (ch == '\\') 
          {
            ReadChar();
            ch = Peek();
          }
          ReadChar();
          sb.Append((char)ch);
          ch = Peek();
        };
        str = sb.ToString();
        return true;
      } 
      else 
      {
        return false;
      }
    }

    private bool ProbeName(ref string str) 
    {
      int ch = Peek();
      if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 128 && ch <= 255) || (ch >= '0' && ch <= '9') || ch == '-' || ch == '_'  || ch == '%'  || ch == '\\') 
      {
        if (ch == '\\') 
        {
          ReadChar();
          ch = Peek();
        }
        System.Text.StringBuilder sb = new System.Text.StringBuilder(ch);
        ReadChar();
        ch = Peek();
        while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 128 && ch <= 255) || (ch >= '0' && ch <= '9') 
          || ch == '-'  || ch == '_' || ch == '%' || ch == '\\') 
        {
          if (ch == '\\') 
          {
            ReadChar();
            ch = Peek();
          }
          ReadChar();
          sb.Append((char)ch);
          ch = Peek();
        };
        str = sb.ToString();
        return true;
      } 
      else 
      {
        return false;
      }
    }

    private bool ProbeURL(ref string str) 
    {
      int ch = Peek();
      if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 128 && ch <= 255) || (ch >= '0' && ch <= '9') || ch == '-' || ch == '%' || ch == '!' || ch == '#' || ch == '$' || ch == '%' || ch == '&' || ch == '*' || ch == '~'  || ch == '_' ) 
      {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(ch);
        ReadChar();
        ch = Peek();
        while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 128 && ch <= 255) || (ch >= '0' && ch <= '9') || ch == '-' || ch == '%'  || ch == '_' ) 
        {
          ReadChar();
          sb.Append((char)ch);
          ch = Peek();
        };
        str = sb.ToString();
        return true;
      } 
      else 
      {
        return false;
      }
    }

    private bool ProbeNumber(ref string str) 
    {
      int ch = Peek();

      if ((ch >= '0' && ch <= '9') || ch == '.') 
      {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(ch);
        ReadChar();
        int chp = ch;
        ch = Peek();
        if (chp == '.' && !(ch >= '0' && ch <= '9')) 
        {
          PutBack((char)chp);
          return false;
        }
        while ((ch >= '0' && ch <= '9') || ch == '.') 
        {
          ReadChar();
          sb.Append((char)ch);
          ch = Peek();
        };
        str = sb.ToString();
        return true;
      } 
      else 
      {
        return false;
      }
    }
    public Token ReadToken() 
    {
      _token = ReadTokenInternal();
      return _token;
    }

    private Token ReadTokenInternal() 
    {
      string tokenValue = "";
      if (Peek() == -1) 
      {
        return Token.EOF;
      };
      if (Probe("\x9") || Probe("\xA") || Probe("\xC") || Probe("\xD") || Probe(" ")) 
      {
        _tokenValue = "";
        return Token.S;
      } 
      else if (Probe("/*")) 
      {
        int ch = Peek();
        while (ch != -1) 
        {
          ReadChar();
          if (ch == '*' && Peek() == '/') 
          {
            ReadChar();
            break;
          }
          ch = Peek();
        }
        return Token.S;
      } 
      else if (Probe("<!--")) 
      {
        return Token.CDO;
      } 
      else if (Probe("-->")) 
      {
        return Token.CDC;
      } 
      else if (Probe("~=")) 
      {
        return Token.INCLUDES;
      } 
      else if (Probe("|=")) 
      {
        return Token.DASHMATCH;
      } 
      else if (ProbeString(ref tokenValue)) 
      {
        _tokenValue = tokenValue;
        return Token.STRING;
      } 
      else if (ProbeIdent(ref tokenValue)) 
      {
        _tokenValue = tokenValue;
        if (Probe("(")) 
        {
          return Token.FUNCTION;
        } 
        else 
        {
          return Token.IDENT;
        };
      } 
      else if (Probe("#") && ProbeName(ref tokenValue)) 
      {
        _tokenValue = tokenValue;
        return Token.HASH;
      } 
      else if (Probe("@import")) 
      {
        return Token.IMPORT_SYM;
      } 
      else if (Probe("@page")) 
      {
        return Token.PAGE_SYM;
      } 
      else if (Probe("@media")) 
      {
        return Token.MEDIA_SYM;
      } 
      else if (Probe("@font-face")) 
      {
        return Token.FONT_FACE_SYM;
      } 
      else if (Probe("@charset")) 
      {
        return Token.CHARSET_SYM;
      } 
      else if (Probe("@") && ProbeIdent(ref tokenValue)) 
      {
        _tokenValue = tokenValue;
        return Token.ATKEYWORD;
      } 
      else if (Probe("!") && SkipSpaces() && Probe("important")) 
      {
        return Token.IMPORTANT_SYM;
      } 
      else if (ProbeNumber(ref tokenValue)) 
      {
        _tokenValue = tokenValue;
        if (Probe("em")) 
        {
          _tokenValue = _tokenValue + "em";
          return Token.EMS;
        } 
        else if (Probe("ex")) 
        {
          _tokenValue = _tokenValue + "ex";
          return Token.EXS;
        } 
        else if (Probe("px")) 
        {
          _tokenValue = _tokenValue + "px";
          return Token.LENGTH;
        } 
        else if (Probe("cm")) 
        {
          _tokenValue = _tokenValue + "cm";
          return Token.LENGTH;
        } 
        else if (Probe("mm")) 
        {
          _tokenValue = _tokenValue + "mm";
          return Token.LENGTH;
        } 
        else if (Probe("in")) 
        {
          _tokenValue = _tokenValue + "in";
          return Token.LENGTH;
        } 
        else if (Probe("pt")) 
        {
          _tokenValue = _tokenValue + "pt";
          return Token.LENGTH;
        } 
        else if (Probe("pc")) 
        {
          _tokenValue = _tokenValue + "pc";
          return Token.LENGTH;
        } 
        else if (Probe("deg")) 
        {
          _tokenValue = _tokenValue + "deg";
          return Token.ANGLE;
        } 
        else if (Probe("rad")) 
        {
          _tokenValue = _tokenValue + "rad";
          return Token.ANGLE;
        } 
        else if (Probe("grad")) 
        {
          _tokenValue = _tokenValue + "grad";
          return Token.ANGLE;
        } 
        else if (Probe("ms")) 
        {
          _tokenValue = _tokenValue + "ms";
          return Token.TIME;
        } 
        else if (Probe("s")) 
        {
          _tokenValue = _tokenValue + "s";
          return Token.TIME;
        } 
        else if (Probe("hz")) 
        {
          _tokenValue = _tokenValue + "hz";
          return Token.FREQ;
        } 
        else if (Probe("khz")) 
        {
          _tokenValue = _tokenValue + "khz";
          return Token.FREQ;
        } 
        else if (Probe("%")) 
        {
          _tokenValue = _tokenValue + "%";
          return Token.PERCENTAGE;
        } 
        else if (ProbeIdent(ref tokenValue)) 
        {
          _tokenValue = _tokenValue + tokenValue;
          return Token.DIMEN;
        } 
        else 
        {
          return Token.NUMBER;
        }
      } 
      else if (Probe("url(")) 
      {
        SkipSpaces();
        if (ProbeString(ref tokenValue)) 
        {
          _tokenValue = tokenValue;
          return Token.URI;
        } 
        else if (ProbeURL(ref tokenValue)) 
        {
          _tokenValue = tokenValue;
          return Token.URI;
        } 
        else 
        {
          _tokenValue = ((char)ReadChar()).ToString();
          return Token.unrecognized;
        }
      } 
      else 
      {
        _tokenValue = ((char)ReadChar()).ToString();
        return Token.SYMBOL;
      }
    }
  }

  public class CSSParser 
  {
    private TextReader _reader;
    private XmlWriter _writer;
    private Tokenizer _tokenizer;
    public CSSParser(TextReader reader, XmlWriter writer) 
    {
      _reader = reader;
      _tokenizer = new Tokenizer(reader);
      _writer = writer;
    }
    
    private bool TokenIs(Token token) 
    {
      return _tokenizer.LastToken == token;
    }

    private void ReadToken() 
    {
      _tokenizer.ReadToken();
    }

    private void SkipSpaces(bool write) 
    {
      bool wasSpace = false;
      while (TokenIs(Token.S) || TokenIs(Token.CDO) || TokenIs(Token.CDC)) 
      {
        _tokenizer.ReadToken();
        wasSpace = true;
      }
      if (write && wasSpace) _writer.WriteString(" ");
    }

    private string TokenExpected(Token token) 
    {
      if (!TokenIs(token)) 
      {
        throw new Exception(String.Format("Token {0} expected, but {1} foud", token, _tokenizer.LastToken));
      };
      string s = _tokenizer.LastTokenValue;
      ReadToken();
      return s;
    }

    private void SymbolExpected(char symbol) 
    {
      Token wasToken = Token.EOF;
      string s;
      try 
      {
        wasToken = _tokenizer.LastToken;
        s = TokenExpected(Token.SYMBOL);
      } 
      catch (Exception e) 
      {
        throw new Exception(String.Format("'{0}' expected, but '{1}' foud", symbol, wasToken), e);
      }
      if (s != new String(symbol, 1)) 
      {
        throw new Exception(String.Format("'{0}' expected, but '{1}' foud", symbol, s));
      }
    }

    private void ReadCharset() 
    {
      TokenExpected(Token.CHARSET_SYM);
      SkipSpaces(false);
      string charset = TokenExpected(Token.STRING);
      SkipSpaces(false);
      SymbolExpected(';');
      SkipSpaces(false);
      _writer.WriteAttributeString("charset", charset);
    }

    private void ReadImport() 
    {
      _writer.WriteStartElement("css:import");
      TokenExpected(Token.IMPORT_SYM);
      SkipSpaces(false);
      string s;
      if (TokenIs(Token.URI)) 
      {
        s = TokenExpected(Token.URI);
      } 
      else 
      {
        s = TokenExpected(Token.STRING);
      };
      SkipSpaces(false);
      _writer.WriteAttributeString("uri", s);
      while (TokenIs(Token.IDENT)) 
      {
        string medium = _tokenizer.LastTokenValue;
        _writer.WriteStartElement("css:medium");
        _writer.WriteAttributeString("value", medium);
        _writer.WriteEndElement();
        SkipSpaces(false);
        ReadToken();
        if (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ",") 
        {
          ReadToken();
          SkipSpaces(false);
        }
      };
      SymbolExpected(';');
      SkipSpaces(false);
      _writer.WriteEndElement();
    }
    
    private bool ReadElementName() 
    {
      if (TokenIs(Token.IDENT) || (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == "*")) 
      {
        if (TokenIs(Token.IDENT)) 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
        } 
        else 
        {
          _writer.WriteString("*");
        }
        ReadToken();
        return true;
      } 
      else 
      {
        return false;
      }
    }

    private void ReadClass() 
    {
      SymbolExpected('.');
      _writer.WriteString("." + _tokenizer.LastTokenValue);
      TokenExpected(Token.IDENT);
    }

    private void ReadAttrib() 
    {
      SymbolExpected('[');
      _writer.WriteString("[");

      SkipSpaces(false);
      _writer.WriteString(_tokenizer.LastTokenValue);
      TokenExpected(Token.IDENT);
      SkipSpaces(true);
      if ((TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == "=") || TokenIs(Token.INCLUDES) || TokenIs(Token.DASHMATCH)) 
      {
        _writer.WriteString(_tokenizer.LastTokenValue);
        ReadToken();
      }
      SkipSpaces(true);
      if (TokenIs(Token.IDENT) || TokenIs(Token.STRING)) 
      {
        // TODO:          _writer.WriteString(_tokenizer.LastTokenValue);
        ReadToken();
      }
      SkipSpaces(false);
      SymbolExpected(']');
      _writer.WriteString("]");
    }

    private void ReadPseudo() 
    {
      SymbolExpected(':');
      _writer.WriteString(":");
      if (TokenIs(Token.IDENT)) 
      {
        _writer.WriteString(_tokenizer.LastTokenValue);
        ReadToken();
      } 
      else 
      {
        _writer.WriteString(_tokenizer.LastTokenValue + "(");
        TokenExpected(Token.FUNCTION);
        SkipSpaces(false);
        _writer.WriteString(_tokenizer.LastTokenValue);
        TokenExpected(Token.IDENT);
        SkipSpaces(false);
        SymbolExpected(')');
        _writer.WriteString(")");
      }
    }

    private bool ReadSimpleSelector() 
    {
      bool wasAnything = ReadElementName();
      for(;;) 
      {
        if (TokenIs(Token.HASH)) 
        {
          _writer.WriteString("#" + _tokenizer.LastTokenValue);
          ReadToken();
          wasAnything = true;
        } 
        else if (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ".") 
        {
          ReadClass();
          wasAnything = true;
        } 
        else if (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == "[") 
        {
          ReadAttrib();
          wasAnything = true;
        } 
        else if (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ":") 
        {
          ReadPseudo();
          wasAnything = true;
        } 
        else 
        {
          break;
        }
      }
      SkipSpaces(true);
      return wasAnything;
    }

    private bool ReadCombinator() 
    {
      bool wasAnything = false;
      if (TokenIs(Token.SYMBOL)) 
      {
        if (_tokenizer.LastTokenValue == "+") 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
          ReadToken();
          wasAnything = true;
          SkipSpaces(true);
        } 
        else if (_tokenizer.LastTokenValue == ">") 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
          ReadToken();
          wasAnything = true;
          SkipSpaces(true);
        };
      }
      return wasAnything;
    }

    private void ReadSelector() 
    {
      _writer.WriteStartElement("css:selector");
      ReadSimpleSelector();
      bool wasAnything = true;
      while (wasAnything) 
      {
        wasAnything = ReadCombinator();
        wasAnything = wasAnything || ReadSimpleSelector();
      }
      _writer.WriteEndElement();
    }

    private void ReadProperty() 
    {
      _writer.WriteAttributeString("property-name", _tokenizer.LastTokenValue);
      TokenExpected(Token.IDENT);
      SkipSpaces(false);
    }

    private void ReadUnaryOperator() 
    {
      if (TokenIs(Token.SYMBOL)) 
      {
        if (_tokenizer.LastTokenValue == "+") 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
          ReadToken();
        } 
        else 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
          SymbolExpected('-');
        }
      } 
      else 
      {
        TokenExpected(Token.SYMBOL);
      }
    }

    private void ReadFunction() 
    {
      _writer.WriteString(_tokenizer.LastTokenValue + "(");       
      TokenExpected(Token.FUNCTION);
      SkipSpaces(false);
      ReadExpr();
      SymbolExpected(')');
      _writer.WriteString(")");       
      SkipSpaces(false);
    }

    private void ReadTerm() 
    {
      if ((TokenIs(Token.SYMBOL) && (_tokenizer.LastTokenValue == "+" || _tokenizer.LastTokenValue == "-"))) 
      {
        ReadUnaryOperator();
      } 
      else if (TokenIs(Token.NUMBER) || TokenIs(Token.PERCENTAGE) || TokenIs(Token.LENGTH) || TokenIs(Token.EMS) || 
        TokenIs(Token.EXS) || TokenIs(Token.ANGLE) || TokenIs(Token.TIME) || TokenIs(Token.FREQ) || 
        TokenIs(Token.STRING) || TokenIs(Token.IDENT) || TokenIs(Token.URI) || 
        TokenIs(Token.UNICODERANGE)) 
      {
        _writer.WriteString(_tokenizer.LastTokenValue);       
        ReadToken();
        SkipSpaces(true);
      } 
      else if (TokenIs(Token.HASH)) 
      {
        _writer.WriteString("#" + _tokenizer.LastTokenValue);       
        ReadToken();
        SkipSpaces(true);
      } 
      else if (TokenIs(Token.FUNCTION)) 
      {
        ReadFunction();
      } 
      else 
      {
        //  int i = 0; // never used? 
      }

    }

    private void ReadOperator() 
    {
      if (TokenIs(Token.SYMBOL)) 
      {
        if (_tokenizer.LastTokenValue == @"/") 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
          ReadToken();
          SkipSpaces(true);
        } 
        else if (_tokenizer.LastTokenValue == @",") 
        {
          _writer.WriteString(_tokenizer.LastTokenValue);
          ReadToken();
          SkipSpaces(true);
        }
      }
    }

    private void ReadExpr() 
    {
      ReadTerm();
      for (;;) 
      {
        ReadOperator(); // TODO: If somethis has been read then TERM must follow
        if ((TokenIs(Token.SYMBOL) && (_tokenizer.LastTokenValue == "+" || _tokenizer.LastTokenValue == "-"))) 
        {
          ReadTerm();
        } 
        else if (TokenIs(Token.NUMBER) || TokenIs(Token.PERCENTAGE) || TokenIs(Token.LENGTH) || TokenIs(Token.EMS) || 
          TokenIs(Token.EXS) || TokenIs(Token.ANGLE) || TokenIs(Token.TIME) || TokenIs(Token.FREQ) || 
          TokenIs(Token.STRING) || TokenIs(Token.IDENT) || TokenIs(Token.URI) || 
          TokenIs(Token.UNICODERANGE)) 
        {
          ReadTerm();
        } 
        else if (TokenIs(Token.HASH)) 
        {
          ReadTerm();
        } 
        else if (TokenIs(Token.FUNCTION)) 
        {
          ReadTerm();
        } 
        else 
        {
          break;
        }
      }
    }

    private void ReadPrio() 
    {
      TokenExpected(Token.IMPORTANT_SYM);
      _writer.WriteAttributeString("important", "yes");
      SkipSpaces(false);
    }

    private void ReadDeclaration() 
    {
      if (TokenIs(Token.IDENT)) 
      {
        _writer.WriteStartElement("css:declaration");
        ReadProperty();
        SymbolExpected(':');
        SkipSpaces(false);
        ReadExpr();
        if (TokenIs(Token.IMPORTANT_SYM)) 
        {
          ReadPrio();
        }
        _writer.WriteEndElement();
      }
    }

    private void ReadRuleset() 
    {
      _writer.WriteStartElement("css:ruleset");
      ReadSelector();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ",") 
      {
        ReadToken();
        SkipSpaces(false);
        ReadSelector();
      };
      SymbolExpected('{');
      SkipSpaces(false);
      ReadDeclaration();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ";") 
      {
        ReadToken();
        SkipSpaces(false);
        ReadDeclaration();
      }
      SymbolExpected('}');
      SkipSpaces(false);
      _writer.WriteEndElement();
    }

    private void ReadMedia() 
    {
      _writer.WriteStartElement("css:media");
      TokenExpected(Token.MEDIA_SYM);
      SkipSpaces(false);
      string medium = TokenExpected(Token.IDENT);
      SkipSpaces(false);
      _writer.WriteStartElement("css:medium");
      _writer.WriteAttributeString("value", medium);
      _writer.WriteEndElement();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ",") 
      {
        ReadToken();
        medium = TokenExpected(Token.IDENT);
        _writer.WriteStartElement("css:medium");
        _writer.WriteAttributeString("value", medium);
        _writer.WriteEndElement();
        SkipSpaces(false);
      }
      
      SymbolExpected('{');
      SkipSpaces(false);
      ReadRuleset();
      SymbolExpected('}');
      SkipSpaces(false);
      _writer.WriteEndElement();
    }

    private void ReadPseudoPage() 
    {
      SymbolExpected(':');
      _writer.WriteAttributeString("pseudo", _tokenizer.LastTokenValue);
      TokenExpected(Token.IDENT);
    }

    private void ReadPage() 
    {
      _writer.WriteStartElement("css:page");
      TokenExpected(Token.PAGE_SYM);
      SkipSpaces(false);
      if (TokenIs(Token.IDENT)) 
      {
        _writer.WriteAttributeString("page", _tokenizer.LastTokenValue);
        ReadToken();
      }
      if (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ":") 
      {
        ReadPseudoPage();
      }
      SkipSpaces(false);
      SymbolExpected('{');
      SkipSpaces(false);
      ReadDeclaration();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ";") 
      {
        SymbolExpected(';');
        SkipSpaces(false);
        ReadDeclaration();
      }
      SymbolExpected('}');
      SkipSpaces(false);
      _writer.WriteEndElement();
    }

    private void ReadATKEYWORD() 
    {
      _writer.WriteStartElement("css:atkeyword");
      _writer.WriteAttributeString("name", _tokenizer.LastTokenValue);
      TokenExpected(Token.ATKEYWORD);
      SkipSpaces(false);
      /*      if (TokenIs(Token.IDENT)) {
              _writer.WriteAttributeString("class-name", _tokenizer.LastTokenValue);
              ReadToken();
            }
            if (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ":") {
              ReadPseudoPage();
            }
      */  
      ReadSelector();
      SkipSpaces(false);
      SymbolExpected('{');
      SkipSpaces(false);
      ReadDeclaration();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ";") 
      {
        SymbolExpected(';');
        SkipSpaces(false);
        ReadDeclaration();
      }
      SymbolExpected('}');
      SkipSpaces(false);
      _writer.WriteEndElement();
    }

    private void ReadFontFace() 
    {
      _writer.WriteStartElement("css:font-face");
      TokenExpected(Token.FONT_FACE_SYM);
      SkipSpaces(false);
      SymbolExpected('{');
      SkipSpaces(false);
      ReadDeclaration();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ";") 
      {
        SymbolExpected(';');
        SkipSpaces(false);
        ReadDeclaration();
      }
      SymbolExpected('}');
      SkipSpaces(false);
      _writer.WriteEndElement();
    }

    private void ReadStylesheet() 
    {
      _writer.WriteStartElement("css", "stylesheet", "http://eleks.lviv.ua/NS/CSS-stylesheet");
      ReadToken();
      SkipSpaces(false);
      if (TokenIs(Token.CHARSET_SYM)) 
      {
        ReadCharset();
      };
      while (TokenIs(Token.IMPORT_SYM)) 
      {
        ReadImport();
      };
      for(;;) 
      {
        if (TokenIs(Token.MEDIA_SYM)) 
        {
          ReadMedia();
        } 
        else if (TokenIs(Token.PAGE_SYM)) 
        {
          ReadPage();
        } 
        else if (TokenIs(Token.FONT_FACE_SYM)) 
        {
          ReadFontFace();
        } 
        else if (TokenIs(Token.ATKEYWORD)) 
        {
          ReadATKEYWORD();
        } 
        else if (TokenIs(Token.EOF)) 
        {
          break;
        } 
        else 
        {
          ReadRuleset();
        }
      }
      _writer.WriteEndElement();
    }

    public void Process() 
    {
      ReadStylesheet();
    }

    public void ReadStyleAttribute() 
    {
      ReadToken();
      
      ReadDeclaration();
      while (TokenIs(Token.SYMBOL) && _tokenizer.LastTokenValue == ";") 
      {
        ReadToken();
        SkipSpaces(false);
        ReadDeclaration();
      }
      _writer.WriteEndElement();
    }
  }
}
