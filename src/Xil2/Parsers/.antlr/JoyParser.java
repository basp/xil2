// Generated from d:\basp\joy\src\Joy\Parsers\Joy.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JoyParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, BOOL=7, INT=8, HEX=9, 
		FLOAT=10, CHAR=11, STRING=12, SYMBOL=13, SINGLE_LINE_COMMENT=14, MULTI_LINE_COMMENT=15, 
		WS=16;
	public static final int
		RULE_cycle = 0, RULE_simpleDefinition = 1, RULE_term = 2, RULE_factor = 3, 
		RULE_setLiteral = 4, RULE_quotationLiteral = 5, RULE_atomicSymbol = 6, 
		RULE_booleanConstant = 7, RULE_integerConstant = 8, RULE_floatConstant = 9, 
		RULE_characterConstant = 10, RULE_stringConstant = 11;
	private static String[] makeRuleNames() {
		return new String[] {
			"cycle", "simpleDefinition", "term", "factor", "setLiteral", "quotationLiteral", 
			"atomicSymbol", "booleanConstant", "integerConstant", "floatConstant", 
			"characterConstant", "stringConstant"
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

	@Override
	public String getGrammarFileName() { return "Joy.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JoyParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class CycleContext extends ParserRuleContext {
		public TermContext term() {
			return getRuleContext(TermContext.class,0);
		}
		public SimpleDefinitionContext simpleDefinition() {
			return getRuleContext(SimpleDefinitionContext.class,0);
		}
		public CycleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cycle; }
	}

	public final CycleContext cycle() throws RecognitionException {
		CycleContext _localctx = new CycleContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_cycle);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(26);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
			case 1:
				{
				setState(24);
				term();
				}
				break;
			case 2:
				{
				setState(25);
				simpleDefinition();
				}
				break;
			}
			setState(28);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SimpleDefinitionContext extends ParserRuleContext {
		public AtomicSymbolContext atomicSymbol() {
			return getRuleContext(AtomicSymbolContext.class,0);
		}
		public TermContext term() {
			return getRuleContext(TermContext.class,0);
		}
		public SimpleDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleDefinition; }
	}

	public final SimpleDefinitionContext simpleDefinition() throws RecognitionException {
		SimpleDefinitionContext _localctx = new SimpleDefinitionContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_simpleDefinition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(30);
			atomicSymbol();
			setState(31);
			match(T__1);
			setState(32);
			term();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TermContext extends ParserRuleContext {
		public List<FactorContext> factor() {
			return getRuleContexts(FactorContext.class);
		}
		public FactorContext factor(int i) {
			return getRuleContext(FactorContext.class,i);
		}
		public TermContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_term; }
	}

	public final TermContext term() throws RecognitionException {
		TermContext _localctx = new TermContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_term);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(37);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__2) | (1L << T__4) | (1L << BOOL) | (1L << INT) | (1L << FLOAT) | (1L << CHAR) | (1L << STRING) | (1L << SYMBOL))) != 0)) {
				{
				{
				setState(34);
				factor();
				}
				}
				setState(39);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FactorContext extends ParserRuleContext {
		public AtomicSymbolContext atomicSymbol() {
			return getRuleContext(AtomicSymbolContext.class,0);
		}
		public BooleanConstantContext booleanConstant() {
			return getRuleContext(BooleanConstantContext.class,0);
		}
		public IntegerConstantContext integerConstant() {
			return getRuleContext(IntegerConstantContext.class,0);
		}
		public FloatConstantContext floatConstant() {
			return getRuleContext(FloatConstantContext.class,0);
		}
		public CharacterConstantContext characterConstant() {
			return getRuleContext(CharacterConstantContext.class,0);
		}
		public StringConstantContext stringConstant() {
			return getRuleContext(StringConstantContext.class,0);
		}
		public SetLiteralContext setLiteral() {
			return getRuleContext(SetLiteralContext.class,0);
		}
		public QuotationLiteralContext quotationLiteral() {
			return getRuleContext(QuotationLiteralContext.class,0);
		}
		public FactorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_factor; }
	}

	public final FactorContext factor() throws RecognitionException {
		FactorContext _localctx = new FactorContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_factor);
		try {
			setState(48);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SYMBOL:
				enterOuterAlt(_localctx, 1);
				{
				setState(40);
				atomicSymbol();
				}
				break;
			case BOOL:
				enterOuterAlt(_localctx, 2);
				{
				setState(41);
				booleanConstant();
				}
				break;
			case INT:
				enterOuterAlt(_localctx, 3);
				{
				setState(42);
				integerConstant();
				}
				break;
			case FLOAT:
				enterOuterAlt(_localctx, 4);
				{
				setState(43);
				floatConstant();
				}
				break;
			case CHAR:
				enterOuterAlt(_localctx, 5);
				{
				setState(44);
				characterConstant();
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 6);
				{
				setState(45);
				stringConstant();
				}
				break;
			case T__2:
				enterOuterAlt(_localctx, 7);
				{
				setState(46);
				setLiteral();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 8);
				{
				setState(47);
				quotationLiteral();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SetLiteralContext extends ParserRuleContext {
		public List<CharacterConstantContext> characterConstant() {
			return getRuleContexts(CharacterConstantContext.class);
		}
		public CharacterConstantContext characterConstant(int i) {
			return getRuleContext(CharacterConstantContext.class,i);
		}
		public List<IntegerConstantContext> integerConstant() {
			return getRuleContexts(IntegerConstantContext.class);
		}
		public IntegerConstantContext integerConstant(int i) {
			return getRuleContext(IntegerConstantContext.class,i);
		}
		public SetLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setLiteral; }
	}

	public final SetLiteralContext setLiteral() throws RecognitionException {
		SetLiteralContext _localctx = new SetLiteralContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_setLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(50);
			match(T__2);
			setState(55);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INT || _la==CHAR) {
				{
				setState(53);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case CHAR:
					{
					setState(51);
					characterConstant();
					}
					break;
				case INT:
					{
					setState(52);
					integerConstant();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(57);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(58);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class QuotationLiteralContext extends ParserRuleContext {
		public TermContext term() {
			return getRuleContext(TermContext.class,0);
		}
		public QuotationLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_quotationLiteral; }
	}

	public final QuotationLiteralContext quotationLiteral() throws RecognitionException {
		QuotationLiteralContext _localctx = new QuotationLiteralContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_quotationLiteral);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(60);
			match(T__4);
			setState(61);
			term();
			setState(62);
			match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AtomicSymbolContext extends ParserRuleContext {
		public TerminalNode SYMBOL() { return getToken(JoyParser.SYMBOL, 0); }
		public AtomicSymbolContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_atomicSymbol; }
	}

	public final AtomicSymbolContext atomicSymbol() throws RecognitionException {
		AtomicSymbolContext _localctx = new AtomicSymbolContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_atomicSymbol);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(64);
			match(SYMBOL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BooleanConstantContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(JoyParser.BOOL, 0); }
		public BooleanConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_booleanConstant; }
	}

	public final BooleanConstantContext booleanConstant() throws RecognitionException {
		BooleanConstantContext _localctx = new BooleanConstantContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_booleanConstant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(66);
			match(BOOL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IntegerConstantContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(JoyParser.INT, 0); }
		public IntegerConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_integerConstant; }
	}

	public final IntegerConstantContext integerConstant() throws RecognitionException {
		IntegerConstantContext _localctx = new IntegerConstantContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_integerConstant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(68);
			match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FloatConstantContext extends ParserRuleContext {
		public TerminalNode FLOAT() { return getToken(JoyParser.FLOAT, 0); }
		public FloatConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_floatConstant; }
	}

	public final FloatConstantContext floatConstant() throws RecognitionException {
		FloatConstantContext _localctx = new FloatConstantContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_floatConstant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(70);
			match(FLOAT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CharacterConstantContext extends ParserRuleContext {
		public TerminalNode CHAR() { return getToken(JoyParser.CHAR, 0); }
		public CharacterConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_characterConstant; }
	}

	public final CharacterConstantContext characterConstant() throws RecognitionException {
		CharacterConstantContext _localctx = new CharacterConstantContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_characterConstant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(72);
			match(CHAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StringConstantContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JoyParser.STRING, 0); }
		public StringConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stringConstant; }
	}

	public final StringConstantContext stringConstant() throws RecognitionException {
		StringConstantContext _localctx = new StringConstantContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_stringConstant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(74);
			match(STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\22O\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t\13\4"+
		"\f\t\f\4\r\t\r\3\2\3\2\5\2\35\n\2\3\2\3\2\3\3\3\3\3\3\3\3\3\4\7\4&\n\4"+
		"\f\4\16\4)\13\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\5\5\63\n\5\3\6\3\6\3\6"+
		"\7\68\n\6\f\6\16\6;\13\6\3\6\3\6\3\7\3\7\3\7\3\7\3\b\3\b\3\t\3\t\3\n\3"+
		"\n\3\13\3\13\3\f\3\f\3\r\3\r\3\r\2\2\16\2\4\6\b\n\f\16\20\22\24\26\30"+
		"\2\2\2M\2\34\3\2\2\2\4 \3\2\2\2\6\'\3\2\2\2\b\62\3\2\2\2\n\64\3\2\2\2"+
		"\f>\3\2\2\2\16B\3\2\2\2\20D\3\2\2\2\22F\3\2\2\2\24H\3\2\2\2\26J\3\2\2"+
		"\2\30L\3\2\2\2\32\35\5\6\4\2\33\35\5\4\3\2\34\32\3\2\2\2\34\33\3\2\2\2"+
		"\35\36\3\2\2\2\36\37\7\3\2\2\37\3\3\2\2\2 !\5\16\b\2!\"\7\4\2\2\"#\5\6"+
		"\4\2#\5\3\2\2\2$&\5\b\5\2%$\3\2\2\2&)\3\2\2\2\'%\3\2\2\2\'(\3\2\2\2(\7"+
		"\3\2\2\2)\'\3\2\2\2*\63\5\16\b\2+\63\5\20\t\2,\63\5\22\n\2-\63\5\24\13"+
		"\2.\63\5\26\f\2/\63\5\30\r\2\60\63\5\n\6\2\61\63\5\f\7\2\62*\3\2\2\2\62"+
		"+\3\2\2\2\62,\3\2\2\2\62-\3\2\2\2\62.\3\2\2\2\62/\3\2\2\2\62\60\3\2\2"+
		"\2\62\61\3\2\2\2\63\t\3\2\2\2\649\7\5\2\2\658\5\26\f\2\668\5\22\n\2\67"+
		"\65\3\2\2\2\67\66\3\2\2\28;\3\2\2\29\67\3\2\2\29:\3\2\2\2:<\3\2\2\2;9"+
		"\3\2\2\2<=\7\6\2\2=\13\3\2\2\2>?\7\7\2\2?@\5\6\4\2@A\7\b\2\2A\r\3\2\2"+
		"\2BC\7\17\2\2C\17\3\2\2\2DE\7\t\2\2E\21\3\2\2\2FG\7\n\2\2G\23\3\2\2\2"+
		"HI\7\f\2\2I\25\3\2\2\2JK\7\r\2\2K\27\3\2\2\2LM\7\16\2\2M\31\3\2\2\2\7"+
		"\34\'\62\679";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}