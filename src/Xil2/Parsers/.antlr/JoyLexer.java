// Generated from d:\basp\joy\src\Joy\Parsers\Joy.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JoyLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, BOOL=7, INT=8, HEX=9, 
		FLOAT=10, CHAR=11, STRING=12, SYMBOL=13, SINGLE_LINE_COMMENT=14, MULTI_LINE_COMMENT=15, 
		WS=16;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "BOOL", "INT", "HEX", 
			"FLOAT", "CHAR", "STRING", "SYMBOL", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", 
			"WS", "SYMBOL_START_CHAR", "SYMBOL_CHAR", "HEXDIGIT", "EXP", "LETTER", 
			"DIGIT", "ESC"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "'=='", "'{'", "'}'", "'['", "']'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, "BOOL", "INT", "HEX", "FLOAT", 
			"CHAR", "STRING", "SYMBOL", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", 
			"WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public JoyLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Joy.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\22\u00ba\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\3\2"+
		"\3\2\3\3\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3"+
		"\b\3\b\3\b\3\b\5\bH\n\b\3\t\5\tK\n\t\3\t\6\tN\n\t\r\t\16\tO\3\n\3\n\3"+
		"\n\6\nU\n\n\r\n\16\nV\3\13\5\13Z\n\13\3\13\6\13]\n\13\r\13\16\13^\3\13"+
		"\3\13\6\13c\n\13\r\13\16\13d\3\13\5\13h\n\13\3\13\5\13k\n\13\3\13\6\13"+
		"n\n\13\r\13\16\13o\3\13\5\13s\n\13\5\13u\n\13\3\f\3\f\3\f\3\r\3\r\3\r"+
		"\7\r}\n\r\f\r\16\r\u0080\13\r\3\r\3\r\3\16\3\16\7\16\u0086\n\16\f\16\16"+
		"\16\u0089\13\16\3\17\3\17\7\17\u008d\n\17\f\17\16\17\u0090\13\17\3\17"+
		"\3\17\3\20\3\20\3\20\3\20\7\20\u0098\n\20\f\20\16\20\u009b\13\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\22\3\22\3\23\3\23\5\23\u00aa"+
		"\n\23\3\24\3\24\3\25\3\25\5\25\u00b0\n\25\3\25\3\25\3\26\3\26\3\27\3\27"+
		"\3\30\3\30\3\30\4~\u0099\2\31\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13"+
		"\25\f\27\r\31\16\33\17\35\20\37\21!\22#\2%\2\'\2)\2+\2-\2/\2\3\2\r\4\2"+
		"ZZzz\4\2$$^^\4\2\f\f\16\17\5\2\13\f\17\17\"\"\t\2#/\61\61<<>\\`|~~\u0080"+
		"\u0080\5\2\62;CHch\4\2GGgg\4\2--//\4\2C\\c|\3\2\62;\n\2$$))^^ddhhpptt"+
		"vv\2\u00c5\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2"+
		"\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27"+
		"\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2"+
		"\2\3\61\3\2\2\2\5\63\3\2\2\2\7\66\3\2\2\2\t8\3\2\2\2\13:\3\2\2\2\r<\3"+
		"\2\2\2\17G\3\2\2\2\21J\3\2\2\2\23Q\3\2\2\2\25t\3\2\2\2\27v\3\2\2\2\31"+
		"y\3\2\2\2\33\u0083\3\2\2\2\35\u008a\3\2\2\2\37\u0093\3\2\2\2!\u00a1\3"+
		"\2\2\2#\u00a5\3\2\2\2%\u00a9\3\2\2\2\'\u00ab\3\2\2\2)\u00ad\3\2\2\2+\u00b3"+
		"\3\2\2\2-\u00b5\3\2\2\2/\u00b7\3\2\2\2\61\62\7\60\2\2\62\4\3\2\2\2\63"+
		"\64\7?\2\2\64\65\7?\2\2\65\6\3\2\2\2\66\67\7}\2\2\67\b\3\2\2\289\7\177"+
		"\2\29\n\3\2\2\2:;\7]\2\2;\f\3\2\2\2<=\7_\2\2=\16\3\2\2\2>?\7v\2\2?@\7"+
		"t\2\2@A\7w\2\2AH\7g\2\2BC\7h\2\2CD\7c\2\2DE\7n\2\2EF\7u\2\2FH\7g\2\2G"+
		">\3\2\2\2GB\3\2\2\2H\20\3\2\2\2IK\7/\2\2JI\3\2\2\2JK\3\2\2\2KM\3\2\2\2"+
		"LN\5-\27\2ML\3\2\2\2NO\3\2\2\2OM\3\2\2\2OP\3\2\2\2P\22\3\2\2\2QR\7\62"+
		"\2\2RT\t\2\2\2SU\5\'\24\2TS\3\2\2\2UV\3\2\2\2VT\3\2\2\2VW\3\2\2\2W\24"+
		"\3\2\2\2XZ\7/\2\2YX\3\2\2\2YZ\3\2\2\2Z\\\3\2\2\2[]\5-\27\2\\[\3\2\2\2"+
		"]^\3\2\2\2^\\\3\2\2\2^_\3\2\2\2_`\3\2\2\2`b\7\60\2\2ac\5-\27\2ba\3\2\2"+
		"\2cd\3\2\2\2db\3\2\2\2de\3\2\2\2eg\3\2\2\2fh\5)\25\2gf\3\2\2\2gh\3\2\2"+
		"\2hu\3\2\2\2ik\7/\2\2ji\3\2\2\2jk\3\2\2\2km\3\2\2\2ln\5-\27\2ml\3\2\2"+
		"\2no\3\2\2\2om\3\2\2\2op\3\2\2\2pr\3\2\2\2qs\5)\25\2rq\3\2\2\2rs\3\2\2"+
		"\2su\3\2\2\2tY\3\2\2\2tj\3\2\2\2u\26\3\2\2\2vw\7)\2\2wx\5+\26\2x\30\3"+
		"\2\2\2y~\7$\2\2z}\5/\30\2{}\n\3\2\2|z\3\2\2\2|{\3\2\2\2}\u0080\3\2\2\2"+
		"~\177\3\2\2\2~|\3\2\2\2\177\u0081\3\2\2\2\u0080~\3\2\2\2\u0081\u0082\7"+
		"$\2\2\u0082\32\3\2\2\2\u0083\u0087\5#\22\2\u0084\u0086\5%\23\2\u0085\u0084"+
		"\3\2\2\2\u0086\u0089\3\2\2\2\u0087\u0085\3\2\2\2\u0087\u0088\3\2\2\2\u0088"+
		"\34\3\2\2\2\u0089\u0087\3\2\2\2\u008a\u008e\7%\2\2\u008b\u008d\n\4\2\2"+
		"\u008c\u008b\3\2\2\2\u008d\u0090\3\2\2\2\u008e\u008c\3\2\2\2\u008e\u008f"+
		"\3\2\2\2\u008f\u0091\3\2\2\2\u0090\u008e\3\2\2\2\u0091\u0092\b\17\2\2"+
		"\u0092\36\3\2\2\2\u0093\u0094\7*\2\2\u0094\u0095\7,\2\2\u0095\u0099\3"+
		"\2\2\2\u0096\u0098\13\2\2\2\u0097\u0096\3\2\2\2\u0098\u009b\3\2\2\2\u0099"+
		"\u009a\3\2\2\2\u0099\u0097\3\2\2\2\u009a\u009c\3\2\2\2\u009b\u0099\3\2"+
		"\2\2\u009c\u009d\7,\2\2\u009d\u009e\7+\2\2\u009e\u009f\3\2\2\2\u009f\u00a0"+
		"\b\20\2\2\u00a0 \3\2\2\2\u00a1\u00a2\t\5\2\2\u00a2\u00a3\3\2\2\2\u00a3"+
		"\u00a4\b\21\2\2\u00a4\"\3\2\2\2\u00a5\u00a6\t\6\2\2\u00a6$\3\2\2\2\u00a7"+
		"\u00aa\5#\22\2\u00a8\u00aa\4\62;\2\u00a9\u00a7\3\2\2\2\u00a9\u00a8\3\2"+
		"\2\2\u00aa&\3\2\2\2\u00ab\u00ac\t\7\2\2\u00ac(\3\2\2\2\u00ad\u00af\t\b"+
		"\2\2\u00ae\u00b0\t\t\2\2\u00af\u00ae\3\2\2\2\u00af\u00b0\3\2\2\2\u00b0"+
		"\u00b1\3\2\2\2\u00b1\u00b2\5\21\t\2\u00b2*\3\2\2\2\u00b3\u00b4\t\n\2\2"+
		"\u00b4,\3\2\2\2\u00b5\u00b6\t\13\2\2\u00b6.\3\2\2\2\u00b7\u00b8\7^\2\2"+
		"\u00b8\u00b9\t\f\2\2\u00b9\60\3\2\2\2\26\2GJOVY^dgjort|~\u0087\u008e\u0099"+
		"\u00a9\u00af\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}