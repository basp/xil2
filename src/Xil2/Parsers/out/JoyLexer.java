// Generated from Joy.g4 by ANTLR 4.12.0
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class JoyLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.12.0", RuntimeMetaData.VERSION); }

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
		"\u0004\u0000\u0010\u00b8\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002"+
		"\u0001\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002"+
		"\u0004\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002"+
		"\u0007\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002"+
		"\u000b\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e"+
		"\u0002\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011"+
		"\u0002\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014"+
		"\u0002\u0015\u0007\u0015\u0002\u0016\u0007\u0016\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0003"+
		"\u0001\u0003\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001\u0006"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0006\u0003\u0006F\b\u0006\u0001\u0007\u0003\u0007"+
		"I\b\u0007\u0001\u0007\u0004\u0007L\b\u0007\u000b\u0007\f\u0007M\u0001"+
		"\b\u0001\b\u0001\b\u0004\bS\b\b\u000b\b\f\bT\u0001\t\u0003\tX\b\t\u0001"+
		"\t\u0004\t[\b\t\u000b\t\f\t\\\u0001\t\u0001\t\u0004\ta\b\t\u000b\t\f\t"+
		"b\u0001\t\u0003\tf\b\t\u0001\t\u0003\ti\b\t\u0001\t\u0004\tl\b\t\u000b"+
		"\t\f\tm\u0001\t\u0003\tq\b\t\u0003\ts\b\t\u0001\n\u0001\n\u0001\n\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0005\u000b{\b\u000b\n\u000b\f\u000b~\t"+
		"\u000b\u0001\u000b\u0001\u000b\u0001\f\u0001\f\u0005\f\u0084\b\f\n\f\f"+
		"\f\u0087\t\f\u0001\r\u0001\r\u0005\r\u008b\b\r\n\r\f\r\u008e\t\r\u0001"+
		"\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0005\u000e"+
		"\u0096\b\u000e\n\u000e\f\u000e\u0099\t\u000e\u0001\u000e\u0001\u000e\u0001"+
		"\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0003\u0011\u00a8"+
		"\b\u0011\u0001\u0012\u0001\u0012\u0001\u0013\u0001\u0013\u0003\u0013\u00ae"+
		"\b\u0013\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0001\u0015\u0001"+
		"\u0015\u0001\u0016\u0001\u0016\u0001\u0016\u0002|\u0097\u0000\u0017\u0001"+
		"\u0001\u0003\u0002\u0005\u0003\u0007\u0004\t\u0005\u000b\u0006\r\u0007"+
		"\u000f\b\u0011\t\u0013\n\u0015\u000b\u0017\f\u0019\r\u001b\u000e\u001d"+
		"\u000f\u001f\u0010!\u0000#\u0000%\u0000\'\u0000)\u0000+\u0000-\u0000\u0001"+
		"\u0000\u000b\u0002\u0000XXxx\u0002\u0000\"\"\\\\\u0002\u0000\n\n\f\r\u0003"+
		"\u0000\t\n\r\r  \u0007\u0000!-//::<Z^z||~~\u0003\u000009AFaf\u0002\u0000"+
		"EEee\u0002\u0000++--\u0002\u0000AZaz\u0001\u000009\b\u0000\"\"\'\'\\\\"+
		"bbffnnrrtt\u00c3\u0000\u0001\u0001\u0000\u0000\u0000\u0000\u0003\u0001"+
		"\u0000\u0000\u0000\u0000\u0005\u0001\u0000\u0000\u0000\u0000\u0007\u0001"+
		"\u0000\u0000\u0000\u0000\t\u0001\u0000\u0000\u0000\u0000\u000b\u0001\u0000"+
		"\u0000\u0000\u0000\r\u0001\u0000\u0000\u0000\u0000\u000f\u0001\u0000\u0000"+
		"\u0000\u0000\u0011\u0001\u0000\u0000\u0000\u0000\u0013\u0001\u0000\u0000"+
		"\u0000\u0000\u0015\u0001\u0000\u0000\u0000\u0000\u0017\u0001\u0000\u0000"+
		"\u0000\u0000\u0019\u0001\u0000\u0000\u0000\u0000\u001b\u0001\u0000\u0000"+
		"\u0000\u0000\u001d\u0001\u0000\u0000\u0000\u0000\u001f\u0001\u0000\u0000"+
		"\u0000\u0001/\u0001\u0000\u0000\u0000\u00031\u0001\u0000\u0000\u0000\u0005"+
		"4\u0001\u0000\u0000\u0000\u00076\u0001\u0000\u0000\u0000\t8\u0001\u0000"+
		"\u0000\u0000\u000b:\u0001\u0000\u0000\u0000\rE\u0001\u0000\u0000\u0000"+
		"\u000fH\u0001\u0000\u0000\u0000\u0011O\u0001\u0000\u0000\u0000\u0013r"+
		"\u0001\u0000\u0000\u0000\u0015t\u0001\u0000\u0000\u0000\u0017w\u0001\u0000"+
		"\u0000\u0000\u0019\u0081\u0001\u0000\u0000\u0000\u001b\u0088\u0001\u0000"+
		"\u0000\u0000\u001d\u0091\u0001\u0000\u0000\u0000\u001f\u009f\u0001\u0000"+
		"\u0000\u0000!\u00a3\u0001\u0000\u0000\u0000#\u00a7\u0001\u0000\u0000\u0000"+
		"%\u00a9\u0001\u0000\u0000\u0000\'\u00ab\u0001\u0000\u0000\u0000)\u00b1"+
		"\u0001\u0000\u0000\u0000+\u00b3\u0001\u0000\u0000\u0000-\u00b5\u0001\u0000"+
		"\u0000\u0000/0\u0005.\u0000\u00000\u0002\u0001\u0000\u0000\u000012\u0005"+
		"=\u0000\u000023\u0005=\u0000\u00003\u0004\u0001\u0000\u0000\u000045\u0005"+
		"{\u0000\u00005\u0006\u0001\u0000\u0000\u000067\u0005}\u0000\u00007\b\u0001"+
		"\u0000\u0000\u000089\u0005[\u0000\u00009\n\u0001\u0000\u0000\u0000:;\u0005"+
		"]\u0000\u0000;\f\u0001\u0000\u0000\u0000<=\u0005t\u0000\u0000=>\u0005"+
		"r\u0000\u0000>?\u0005u\u0000\u0000?F\u0005e\u0000\u0000@A\u0005f\u0000"+
		"\u0000AB\u0005a\u0000\u0000BC\u0005l\u0000\u0000CD\u0005s\u0000\u0000"+
		"DF\u0005e\u0000\u0000E<\u0001\u0000\u0000\u0000E@\u0001\u0000\u0000\u0000"+
		"F\u000e\u0001\u0000\u0000\u0000GI\u0005-\u0000\u0000HG\u0001\u0000\u0000"+
		"\u0000HI\u0001\u0000\u0000\u0000IK\u0001\u0000\u0000\u0000JL\u0003+\u0015"+
		"\u0000KJ\u0001\u0000\u0000\u0000LM\u0001\u0000\u0000\u0000MK\u0001\u0000"+
		"\u0000\u0000MN\u0001\u0000\u0000\u0000N\u0010\u0001\u0000\u0000\u0000"+
		"OP\u00050\u0000\u0000PR\u0007\u0000\u0000\u0000QS\u0003%\u0012\u0000R"+
		"Q\u0001\u0000\u0000\u0000ST\u0001\u0000\u0000\u0000TR\u0001\u0000\u0000"+
		"\u0000TU\u0001\u0000\u0000\u0000U\u0012\u0001\u0000\u0000\u0000VX\u0005"+
		"-\u0000\u0000WV\u0001\u0000\u0000\u0000WX\u0001\u0000\u0000\u0000XZ\u0001"+
		"\u0000\u0000\u0000Y[\u0003+\u0015\u0000ZY\u0001\u0000\u0000\u0000[\\\u0001"+
		"\u0000\u0000\u0000\\Z\u0001\u0000\u0000\u0000\\]\u0001\u0000\u0000\u0000"+
		"]^\u0001\u0000\u0000\u0000^`\u0005.\u0000\u0000_a\u0003+\u0015\u0000`"+
		"_\u0001\u0000\u0000\u0000ab\u0001\u0000\u0000\u0000b`\u0001\u0000\u0000"+
		"\u0000bc\u0001\u0000\u0000\u0000ce\u0001\u0000\u0000\u0000df\u0003\'\u0013"+
		"\u0000ed\u0001\u0000\u0000\u0000ef\u0001\u0000\u0000\u0000fs\u0001\u0000"+
		"\u0000\u0000gi\u0005-\u0000\u0000hg\u0001\u0000\u0000\u0000hi\u0001\u0000"+
		"\u0000\u0000ik\u0001\u0000\u0000\u0000jl\u0003+\u0015\u0000kj\u0001\u0000"+
		"\u0000\u0000lm\u0001\u0000\u0000\u0000mk\u0001\u0000\u0000\u0000mn\u0001"+
		"\u0000\u0000\u0000np\u0001\u0000\u0000\u0000oq\u0003\'\u0013\u0000po\u0001"+
		"\u0000\u0000\u0000pq\u0001\u0000\u0000\u0000qs\u0001\u0000\u0000\u0000"+
		"rW\u0001\u0000\u0000\u0000rh\u0001\u0000\u0000\u0000s\u0014\u0001\u0000"+
		"\u0000\u0000tu\u0005\'\u0000\u0000uv\u0003)\u0014\u0000v\u0016\u0001\u0000"+
		"\u0000\u0000w|\u0005\"\u0000\u0000x{\u0003-\u0016\u0000y{\b\u0001\u0000"+
		"\u0000zx\u0001\u0000\u0000\u0000zy\u0001\u0000\u0000\u0000{~\u0001\u0000"+
		"\u0000\u0000|}\u0001\u0000\u0000\u0000|z\u0001\u0000\u0000\u0000}\u007f"+
		"\u0001\u0000\u0000\u0000~|\u0001\u0000\u0000\u0000\u007f\u0080\u0005\""+
		"\u0000\u0000\u0080\u0018\u0001\u0000\u0000\u0000\u0081\u0085\u0003!\u0010"+
		"\u0000\u0082\u0084\u0003#\u0011\u0000\u0083\u0082\u0001\u0000\u0000\u0000"+
		"\u0084\u0087\u0001\u0000\u0000\u0000\u0085\u0083\u0001\u0000\u0000\u0000"+
		"\u0085\u0086\u0001\u0000\u0000\u0000\u0086\u001a\u0001\u0000\u0000\u0000"+
		"\u0087\u0085\u0001\u0000\u0000\u0000\u0088\u008c\u0005#\u0000\u0000\u0089"+
		"\u008b\b\u0002\u0000\u0000\u008a\u0089\u0001\u0000\u0000\u0000\u008b\u008e"+
		"\u0001\u0000\u0000\u0000\u008c\u008a\u0001\u0000\u0000\u0000\u008c\u008d"+
		"\u0001\u0000\u0000\u0000\u008d\u008f\u0001\u0000\u0000\u0000\u008e\u008c"+
		"\u0001\u0000\u0000\u0000\u008f\u0090\u0006\r\u0000\u0000\u0090\u001c\u0001"+
		"\u0000\u0000\u0000\u0091\u0092\u0005(\u0000\u0000\u0092\u0093\u0005*\u0000"+
		"\u0000\u0093\u0097\u0001\u0000\u0000\u0000\u0094\u0096\t\u0000\u0000\u0000"+
		"\u0095\u0094\u0001\u0000\u0000\u0000\u0096\u0099\u0001\u0000\u0000\u0000"+
		"\u0097\u0098\u0001\u0000\u0000\u0000\u0097\u0095\u0001\u0000\u0000\u0000"+
		"\u0098\u009a\u0001\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000\u0000"+
		"\u009a\u009b\u0005*\u0000\u0000\u009b\u009c\u0005)\u0000\u0000\u009c\u009d"+
		"\u0001\u0000\u0000\u0000\u009d\u009e\u0006\u000e\u0000\u0000\u009e\u001e"+
		"\u0001\u0000\u0000\u0000\u009f\u00a0\u0007\u0003\u0000\u0000\u00a0\u00a1"+
		"\u0001\u0000\u0000\u0000\u00a1\u00a2\u0006\u000f\u0000\u0000\u00a2 \u0001"+
		"\u0000\u0000\u0000\u00a3\u00a4\u0007\u0004\u0000\u0000\u00a4\"\u0001\u0000"+
		"\u0000\u0000\u00a5\u00a8\u0003!\u0010\u0000\u00a6\u00a8\u000209\u0000"+
		"\u00a7\u00a5\u0001\u0000\u0000\u0000\u00a7\u00a6\u0001\u0000\u0000\u0000"+
		"\u00a8$\u0001\u0000\u0000\u0000\u00a9\u00aa\u0007\u0005\u0000\u0000\u00aa"+
		"&\u0001\u0000\u0000\u0000\u00ab\u00ad\u0007\u0006\u0000\u0000\u00ac\u00ae"+
		"\u0007\u0007\u0000\u0000\u00ad\u00ac\u0001\u0000\u0000\u0000\u00ad\u00ae"+
		"\u0001\u0000\u0000\u0000\u00ae\u00af\u0001\u0000\u0000\u0000\u00af\u00b0"+
		"\u0003\u000f\u0007\u0000\u00b0(\u0001\u0000\u0000\u0000\u00b1\u00b2\u0007"+
		"\b\u0000\u0000\u00b2*\u0001\u0000\u0000\u0000\u00b3\u00b4\u0007\t\u0000"+
		"\u0000\u00b4,\u0001\u0000\u0000\u0000\u00b5\u00b6\u0005\\\u0000\u0000"+
		"\u00b6\u00b7\u0007\n\u0000\u0000\u00b7.\u0001\u0000\u0000\u0000\u0014"+
		"\u0000EHMTW\\behmprz|\u0085\u008c\u0097\u00a7\u00ad\u0001\u0006\u0000"+
		"\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}