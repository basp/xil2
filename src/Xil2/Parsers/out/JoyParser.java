// Generated from Joy.g4 by ANTLR 4.12.0
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class JoyParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.12.0", RuntimeMetaData.VERSION); }

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

	@SuppressWarnings("CheckReturnValue")
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterCycle(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitCycle(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterSimpleDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitSimpleDefinition(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterTerm(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitTerm(this);
		}
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
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 15784L) != 0)) {
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

	@SuppressWarnings("CheckReturnValue")
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterFactor(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitFactor(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterSetLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitSetLiteral(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class QuotationLiteralContext extends ParserRuleContext {
		public TermContext term() {
			return getRuleContext(TermContext.class,0);
		}
		public QuotationLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_quotationLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterQuotationLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitQuotationLiteral(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class AtomicSymbolContext extends ParserRuleContext {
		public TerminalNode SYMBOL() { return getToken(JoyParser.SYMBOL, 0); }
		public AtomicSymbolContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_atomicSymbol; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterAtomicSymbol(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitAtomicSymbol(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class BooleanConstantContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(JoyParser.BOOL, 0); }
		public BooleanConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_booleanConstant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterBooleanConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitBooleanConstant(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class IntegerConstantContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(JoyParser.INT, 0); }
		public IntegerConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_integerConstant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterIntegerConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitIntegerConstant(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class FloatConstantContext extends ParserRuleContext {
		public TerminalNode FLOAT() { return getToken(JoyParser.FLOAT, 0); }
		public FloatConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_floatConstant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterFloatConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitFloatConstant(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class CharacterConstantContext extends ParserRuleContext {
		public TerminalNode CHAR() { return getToken(JoyParser.CHAR, 0); }
		public CharacterConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_characterConstant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterCharacterConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitCharacterConstant(this);
		}
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

	@SuppressWarnings("CheckReturnValue")
	public static class StringConstantContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JoyParser.STRING, 0); }
		public StringConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stringConstant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).enterStringConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JoyListener ) ((JoyListener)listener).exitStringConstant(this);
		}
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
		"\u0004\u0001\u0010M\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0001"+
		"\u0000\u0001\u0000\u0003\u0000\u001b\b\u0000\u0001\u0000\u0001\u0000\u0001"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0005\u0002$\b"+
		"\u0002\n\u0002\f\u0002\'\t\u0002\u0001\u0003\u0001\u0003\u0001\u0003\u0001"+
		"\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u00031\b"+
		"\u0003\u0001\u0004\u0001\u0004\u0001\u0004\u0005\u00046\b\u0004\n\u0004"+
		"\f\u00049\t\u0004\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001"+
		"\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0001"+
		"\b\u0001\b\u0001\t\u0001\t\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001"+
		"\u000b\u0000\u0000\f\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014"+
		"\u0016\u0000\u0000K\u0000\u001a\u0001\u0000\u0000\u0000\u0002\u001e\u0001"+
		"\u0000\u0000\u0000\u0004%\u0001\u0000\u0000\u0000\u00060\u0001\u0000\u0000"+
		"\u0000\b2\u0001\u0000\u0000\u0000\n<\u0001\u0000\u0000\u0000\f@\u0001"+
		"\u0000\u0000\u0000\u000eB\u0001\u0000\u0000\u0000\u0010D\u0001\u0000\u0000"+
		"\u0000\u0012F\u0001\u0000\u0000\u0000\u0014H\u0001\u0000\u0000\u0000\u0016"+
		"J\u0001\u0000\u0000\u0000\u0018\u001b\u0003\u0004\u0002\u0000\u0019\u001b"+
		"\u0003\u0002\u0001\u0000\u001a\u0018\u0001\u0000\u0000\u0000\u001a\u0019"+
		"\u0001\u0000\u0000\u0000\u001b\u001c\u0001\u0000\u0000\u0000\u001c\u001d"+
		"\u0005\u0001\u0000\u0000\u001d\u0001\u0001\u0000\u0000\u0000\u001e\u001f"+
		"\u0003\f\u0006\u0000\u001f \u0005\u0002\u0000\u0000 !\u0003\u0004\u0002"+
		"\u0000!\u0003\u0001\u0000\u0000\u0000\"$\u0003\u0006\u0003\u0000#\"\u0001"+
		"\u0000\u0000\u0000$\'\u0001\u0000\u0000\u0000%#\u0001\u0000\u0000\u0000"+
		"%&\u0001\u0000\u0000\u0000&\u0005\u0001\u0000\u0000\u0000\'%\u0001\u0000"+
		"\u0000\u0000(1\u0003\f\u0006\u0000)1\u0003\u000e\u0007\u0000*1\u0003\u0010"+
		"\b\u0000+1\u0003\u0012\t\u0000,1\u0003\u0014\n\u0000-1\u0003\u0016\u000b"+
		"\u0000.1\u0003\b\u0004\u0000/1\u0003\n\u0005\u00000(\u0001\u0000\u0000"+
		"\u00000)\u0001\u0000\u0000\u00000*\u0001\u0000\u0000\u00000+\u0001\u0000"+
		"\u0000\u00000,\u0001\u0000\u0000\u00000-\u0001\u0000\u0000\u00000.\u0001"+
		"\u0000\u0000\u00000/\u0001\u0000\u0000\u00001\u0007\u0001\u0000\u0000"+
		"\u000027\u0005\u0003\u0000\u000036\u0003\u0014\n\u000046\u0003\u0010\b"+
		"\u000053\u0001\u0000\u0000\u000054\u0001\u0000\u0000\u000069\u0001\u0000"+
		"\u0000\u000075\u0001\u0000\u0000\u000078\u0001\u0000\u0000\u00008:\u0001"+
		"\u0000\u0000\u000097\u0001\u0000\u0000\u0000:;\u0005\u0004\u0000\u0000"+
		";\t\u0001\u0000\u0000\u0000<=\u0005\u0005\u0000\u0000=>\u0003\u0004\u0002"+
		"\u0000>?\u0005\u0006\u0000\u0000?\u000b\u0001\u0000\u0000\u0000@A\u0005"+
		"\r\u0000\u0000A\r\u0001\u0000\u0000\u0000BC\u0005\u0007\u0000\u0000C\u000f"+
		"\u0001\u0000\u0000\u0000DE\u0005\b\u0000\u0000E\u0011\u0001\u0000\u0000"+
		"\u0000FG\u0005\n\u0000\u0000G\u0013\u0001\u0000\u0000\u0000HI\u0005\u000b"+
		"\u0000\u0000I\u0015\u0001\u0000\u0000\u0000JK\u0005\f\u0000\u0000K\u0017"+
		"\u0001\u0000\u0000\u0000\u0005\u001a%057";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}