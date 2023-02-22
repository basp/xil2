# Generated from .\Joy.g4 by ANTLR 4.12.0
# encoding: utf-8
from antlr4 import *
from io import StringIO
import sys
if sys.version_info[1] > 5:
	from typing import TextIO
else:
	from typing.io import TextIO

def serializedATN():
    return [
        4,1,16,77,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
        6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,1,0,1,0,3,0,27,8,0,
        1,0,1,0,1,1,1,1,1,1,1,1,1,2,5,2,36,8,2,10,2,12,2,39,9,2,1,3,1,3,
        1,3,1,3,1,3,1,3,1,3,1,3,3,3,49,8,3,1,4,1,4,1,4,5,4,54,8,4,10,4,12,
        4,57,9,4,1,4,1,4,1,5,1,5,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,
        1,10,1,10,1,11,1,11,1,11,0,0,12,0,2,4,6,8,10,12,14,16,18,20,22,0,
        0,75,0,26,1,0,0,0,2,30,1,0,0,0,4,37,1,0,0,0,6,48,1,0,0,0,8,50,1,
        0,0,0,10,60,1,0,0,0,12,64,1,0,0,0,14,66,1,0,0,0,16,68,1,0,0,0,18,
        70,1,0,0,0,20,72,1,0,0,0,22,74,1,0,0,0,24,27,3,4,2,0,25,27,3,2,1,
        0,26,24,1,0,0,0,26,25,1,0,0,0,27,28,1,0,0,0,28,29,5,1,0,0,29,1,1,
        0,0,0,30,31,3,12,6,0,31,32,5,2,0,0,32,33,3,4,2,0,33,3,1,0,0,0,34,
        36,3,6,3,0,35,34,1,0,0,0,36,39,1,0,0,0,37,35,1,0,0,0,37,38,1,0,0,
        0,38,5,1,0,0,0,39,37,1,0,0,0,40,49,3,12,6,0,41,49,3,14,7,0,42,49,
        3,16,8,0,43,49,3,18,9,0,44,49,3,20,10,0,45,49,3,22,11,0,46,49,3,
        8,4,0,47,49,3,10,5,0,48,40,1,0,0,0,48,41,1,0,0,0,48,42,1,0,0,0,48,
        43,1,0,0,0,48,44,1,0,0,0,48,45,1,0,0,0,48,46,1,0,0,0,48,47,1,0,0,
        0,49,7,1,0,0,0,50,55,5,3,0,0,51,54,3,20,10,0,52,54,3,16,8,0,53,51,
        1,0,0,0,53,52,1,0,0,0,54,57,1,0,0,0,55,53,1,0,0,0,55,56,1,0,0,0,
        56,58,1,0,0,0,57,55,1,0,0,0,58,59,5,4,0,0,59,9,1,0,0,0,60,61,5,5,
        0,0,61,62,3,4,2,0,62,63,5,6,0,0,63,11,1,0,0,0,64,65,5,13,0,0,65,
        13,1,0,0,0,66,67,5,7,0,0,67,15,1,0,0,0,68,69,5,8,0,0,69,17,1,0,0,
        0,70,71,5,10,0,0,71,19,1,0,0,0,72,73,5,11,0,0,73,21,1,0,0,0,74,75,
        5,12,0,0,75,23,1,0,0,0,5,26,37,48,53,55
    ]

class JoyParser ( Parser ):

    grammarFileName = "Joy.g4"

    atn = ATNDeserializer().deserialize(serializedATN())

    decisionsToDFA = [ DFA(ds, i) for i, ds in enumerate(atn.decisionToState) ]

    sharedContextCache = PredictionContextCache()

    literalNames = [ "<INVALID>", "'.'", "'=='", "'{'", "'}'", "'['", "']'" ]

    symbolicNames = [ "<INVALID>", "<INVALID>", "<INVALID>", "<INVALID>", 
                      "<INVALID>", "<INVALID>", "<INVALID>", "BOOL", "INT", 
                      "HEX", "FLOAT", "CHAR", "STRING", "SYMBOL", "SINGLE_LINE_COMMENT", 
                      "MULTI_LINE_COMMENT", "WS" ]

    RULE_cycle = 0
    RULE_simpleDefinition = 1
    RULE_term = 2
    RULE_factor = 3
    RULE_setLiteral = 4
    RULE_quotationLiteral = 5
    RULE_atomicSymbol = 6
    RULE_booleanConstant = 7
    RULE_integerConstant = 8
    RULE_floatConstant = 9
    RULE_characterConstant = 10
    RULE_stringConstant = 11

    ruleNames =  [ "cycle", "simpleDefinition", "term", "factor", "setLiteral", 
                   "quotationLiteral", "atomicSymbol", "booleanConstant", 
                   "integerConstant", "floatConstant", "characterConstant", 
                   "stringConstant" ]

    EOF = Token.EOF
    T__0=1
    T__1=2
    T__2=3
    T__3=4
    T__4=5
    T__5=6
    BOOL=7
    INT=8
    HEX=9
    FLOAT=10
    CHAR=11
    STRING=12
    SYMBOL=13
    SINGLE_LINE_COMMENT=14
    MULTI_LINE_COMMENT=15
    WS=16

    def __init__(self, input:TokenStream, output:TextIO = sys.stdout):
        super().__init__(input, output)
        self.checkVersion("4.12.0")
        self._interp = ParserATNSimulator(self, self.atn, self.decisionsToDFA, self.sharedContextCache)
        self._predicates = None




    class CycleContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def term(self):
            return self.getTypedRuleContext(JoyParser.TermContext,0)


        def simpleDefinition(self):
            return self.getTypedRuleContext(JoyParser.SimpleDefinitionContext,0)


        def getRuleIndex(self):
            return JoyParser.RULE_cycle

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterCycle" ):
                listener.enterCycle(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitCycle" ):
                listener.exitCycle(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitCycle" ):
                return visitor.visitCycle(self)
            else:
                return visitor.visitChildren(self)




    def cycle(self):

        localctx = JoyParser.CycleContext(self, self._ctx, self.state)
        self.enterRule(localctx, 0, self.RULE_cycle)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 26
            self._errHandler.sync(self)
            la_ = self._interp.adaptivePredict(self._input,0,self._ctx)
            if la_ == 1:
                self.state = 24
                self.term()
                pass

            elif la_ == 2:
                self.state = 25
                self.simpleDefinition()
                pass


            self.state = 28
            self.match(JoyParser.T__0)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class SimpleDefinitionContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def atomicSymbol(self):
            return self.getTypedRuleContext(JoyParser.AtomicSymbolContext,0)


        def term(self):
            return self.getTypedRuleContext(JoyParser.TermContext,0)


        def getRuleIndex(self):
            return JoyParser.RULE_simpleDefinition

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterSimpleDefinition" ):
                listener.enterSimpleDefinition(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitSimpleDefinition" ):
                listener.exitSimpleDefinition(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitSimpleDefinition" ):
                return visitor.visitSimpleDefinition(self)
            else:
                return visitor.visitChildren(self)




    def simpleDefinition(self):

        localctx = JoyParser.SimpleDefinitionContext(self, self._ctx, self.state)
        self.enterRule(localctx, 2, self.RULE_simpleDefinition)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 30
            self.atomicSymbol()
            self.state = 31
            self.match(JoyParser.T__1)
            self.state = 32
            self.term()
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class TermContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def factor(self, i:int=None):
            if i is None:
                return self.getTypedRuleContexts(JoyParser.FactorContext)
            else:
                return self.getTypedRuleContext(JoyParser.FactorContext,i)


        def getRuleIndex(self):
            return JoyParser.RULE_term

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterTerm" ):
                listener.enterTerm(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitTerm" ):
                listener.exitTerm(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitTerm" ):
                return visitor.visitTerm(self)
            else:
                return visitor.visitChildren(self)




    def term(self):

        localctx = JoyParser.TermContext(self, self._ctx, self.state)
        self.enterRule(localctx, 4, self.RULE_term)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 37
            self._errHandler.sync(self)
            _la = self._input.LA(1)
            while (((_la) & ~0x3f) == 0 and ((1 << _la) & 15784) != 0):
                self.state = 34
                self.factor()
                self.state = 39
                self._errHandler.sync(self)
                _la = self._input.LA(1)

        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class FactorContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def atomicSymbol(self):
            return self.getTypedRuleContext(JoyParser.AtomicSymbolContext,0)


        def booleanConstant(self):
            return self.getTypedRuleContext(JoyParser.BooleanConstantContext,0)


        def integerConstant(self):
            return self.getTypedRuleContext(JoyParser.IntegerConstantContext,0)


        def floatConstant(self):
            return self.getTypedRuleContext(JoyParser.FloatConstantContext,0)


        def characterConstant(self):
            return self.getTypedRuleContext(JoyParser.CharacterConstantContext,0)


        def stringConstant(self):
            return self.getTypedRuleContext(JoyParser.StringConstantContext,0)


        def setLiteral(self):
            return self.getTypedRuleContext(JoyParser.SetLiteralContext,0)


        def quotationLiteral(self):
            return self.getTypedRuleContext(JoyParser.QuotationLiteralContext,0)


        def getRuleIndex(self):
            return JoyParser.RULE_factor

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterFactor" ):
                listener.enterFactor(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitFactor" ):
                listener.exitFactor(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitFactor" ):
                return visitor.visitFactor(self)
            else:
                return visitor.visitChildren(self)




    def factor(self):

        localctx = JoyParser.FactorContext(self, self._ctx, self.state)
        self.enterRule(localctx, 6, self.RULE_factor)
        try:
            self.state = 48
            self._errHandler.sync(self)
            token = self._input.LA(1)
            if token in [13]:
                self.enterOuterAlt(localctx, 1)
                self.state = 40
                self.atomicSymbol()
                pass
            elif token in [7]:
                self.enterOuterAlt(localctx, 2)
                self.state = 41
                self.booleanConstant()
                pass
            elif token in [8]:
                self.enterOuterAlt(localctx, 3)
                self.state = 42
                self.integerConstant()
                pass
            elif token in [10]:
                self.enterOuterAlt(localctx, 4)
                self.state = 43
                self.floatConstant()
                pass
            elif token in [11]:
                self.enterOuterAlt(localctx, 5)
                self.state = 44
                self.characterConstant()
                pass
            elif token in [12]:
                self.enterOuterAlt(localctx, 6)
                self.state = 45
                self.stringConstant()
                pass
            elif token in [3]:
                self.enterOuterAlt(localctx, 7)
                self.state = 46
                self.setLiteral()
                pass
            elif token in [5]:
                self.enterOuterAlt(localctx, 8)
                self.state = 47
                self.quotationLiteral()
                pass
            else:
                raise NoViableAltException(self)

        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class SetLiteralContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def characterConstant(self, i:int=None):
            if i is None:
                return self.getTypedRuleContexts(JoyParser.CharacterConstantContext)
            else:
                return self.getTypedRuleContext(JoyParser.CharacterConstantContext,i)


        def integerConstant(self, i:int=None):
            if i is None:
                return self.getTypedRuleContexts(JoyParser.IntegerConstantContext)
            else:
                return self.getTypedRuleContext(JoyParser.IntegerConstantContext,i)


        def getRuleIndex(self):
            return JoyParser.RULE_setLiteral

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterSetLiteral" ):
                listener.enterSetLiteral(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitSetLiteral" ):
                listener.exitSetLiteral(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitSetLiteral" ):
                return visitor.visitSetLiteral(self)
            else:
                return visitor.visitChildren(self)




    def setLiteral(self):

        localctx = JoyParser.SetLiteralContext(self, self._ctx, self.state)
        self.enterRule(localctx, 8, self.RULE_setLiteral)
        self._la = 0 # Token type
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 50
            self.match(JoyParser.T__2)
            self.state = 55
            self._errHandler.sync(self)
            _la = self._input.LA(1)
            while _la==8 or _la==11:
                self.state = 53
                self._errHandler.sync(self)
                token = self._input.LA(1)
                if token in [11]:
                    self.state = 51
                    self.characterConstant()
                    pass
                elif token in [8]:
                    self.state = 52
                    self.integerConstant()
                    pass
                else:
                    raise NoViableAltException(self)

                self.state = 57
                self._errHandler.sync(self)
                _la = self._input.LA(1)

            self.state = 58
            self.match(JoyParser.T__3)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class QuotationLiteralContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def term(self):
            return self.getTypedRuleContext(JoyParser.TermContext,0)


        def getRuleIndex(self):
            return JoyParser.RULE_quotationLiteral

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterQuotationLiteral" ):
                listener.enterQuotationLiteral(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitQuotationLiteral" ):
                listener.exitQuotationLiteral(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitQuotationLiteral" ):
                return visitor.visitQuotationLiteral(self)
            else:
                return visitor.visitChildren(self)




    def quotationLiteral(self):

        localctx = JoyParser.QuotationLiteralContext(self, self._ctx, self.state)
        self.enterRule(localctx, 10, self.RULE_quotationLiteral)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 60
            self.match(JoyParser.T__4)
            self.state = 61
            self.term()
            self.state = 62
            self.match(JoyParser.T__5)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class AtomicSymbolContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def SYMBOL(self):
            return self.getToken(JoyParser.SYMBOL, 0)

        def getRuleIndex(self):
            return JoyParser.RULE_atomicSymbol

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterAtomicSymbol" ):
                listener.enterAtomicSymbol(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitAtomicSymbol" ):
                listener.exitAtomicSymbol(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitAtomicSymbol" ):
                return visitor.visitAtomicSymbol(self)
            else:
                return visitor.visitChildren(self)




    def atomicSymbol(self):

        localctx = JoyParser.AtomicSymbolContext(self, self._ctx, self.state)
        self.enterRule(localctx, 12, self.RULE_atomicSymbol)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 64
            self.match(JoyParser.SYMBOL)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class BooleanConstantContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def BOOL(self):
            return self.getToken(JoyParser.BOOL, 0)

        def getRuleIndex(self):
            return JoyParser.RULE_booleanConstant

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterBooleanConstant" ):
                listener.enterBooleanConstant(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitBooleanConstant" ):
                listener.exitBooleanConstant(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitBooleanConstant" ):
                return visitor.visitBooleanConstant(self)
            else:
                return visitor.visitChildren(self)




    def booleanConstant(self):

        localctx = JoyParser.BooleanConstantContext(self, self._ctx, self.state)
        self.enterRule(localctx, 14, self.RULE_booleanConstant)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 66
            self.match(JoyParser.BOOL)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class IntegerConstantContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def INT(self):
            return self.getToken(JoyParser.INT, 0)

        def getRuleIndex(self):
            return JoyParser.RULE_integerConstant

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterIntegerConstant" ):
                listener.enterIntegerConstant(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitIntegerConstant" ):
                listener.exitIntegerConstant(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitIntegerConstant" ):
                return visitor.visitIntegerConstant(self)
            else:
                return visitor.visitChildren(self)




    def integerConstant(self):

        localctx = JoyParser.IntegerConstantContext(self, self._ctx, self.state)
        self.enterRule(localctx, 16, self.RULE_integerConstant)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 68
            self.match(JoyParser.INT)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class FloatConstantContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def FLOAT(self):
            return self.getToken(JoyParser.FLOAT, 0)

        def getRuleIndex(self):
            return JoyParser.RULE_floatConstant

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterFloatConstant" ):
                listener.enterFloatConstant(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitFloatConstant" ):
                listener.exitFloatConstant(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitFloatConstant" ):
                return visitor.visitFloatConstant(self)
            else:
                return visitor.visitChildren(self)




    def floatConstant(self):

        localctx = JoyParser.FloatConstantContext(self, self._ctx, self.state)
        self.enterRule(localctx, 18, self.RULE_floatConstant)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 70
            self.match(JoyParser.FLOAT)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class CharacterConstantContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def CHAR(self):
            return self.getToken(JoyParser.CHAR, 0)

        def getRuleIndex(self):
            return JoyParser.RULE_characterConstant

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterCharacterConstant" ):
                listener.enterCharacterConstant(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitCharacterConstant" ):
                listener.exitCharacterConstant(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitCharacterConstant" ):
                return visitor.visitCharacterConstant(self)
            else:
                return visitor.visitChildren(self)




    def characterConstant(self):

        localctx = JoyParser.CharacterConstantContext(self, self._ctx, self.state)
        self.enterRule(localctx, 20, self.RULE_characterConstant)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 72
            self.match(JoyParser.CHAR)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx


    class StringConstantContext(ParserRuleContext):
        __slots__ = 'parser'

        def __init__(self, parser, parent:ParserRuleContext=None, invokingState:int=-1):
            super().__init__(parent, invokingState)
            self.parser = parser

        def STRING(self):
            return self.getToken(JoyParser.STRING, 0)

        def getRuleIndex(self):
            return JoyParser.RULE_stringConstant

        def enterRule(self, listener:ParseTreeListener):
            if hasattr( listener, "enterStringConstant" ):
                listener.enterStringConstant(self)

        def exitRule(self, listener:ParseTreeListener):
            if hasattr( listener, "exitStringConstant" ):
                listener.exitStringConstant(self)

        def accept(self, visitor:ParseTreeVisitor):
            if hasattr( visitor, "visitStringConstant" ):
                return visitor.visitStringConstant(self)
            else:
                return visitor.visitChildren(self)




    def stringConstant(self):

        localctx = JoyParser.StringConstantContext(self, self._ctx, self.state)
        self.enterRule(localctx, 22, self.RULE_stringConstant)
        try:
            self.enterOuterAlt(localctx, 1)
            self.state = 74
            self.match(JoyParser.STRING)
        except RecognitionException as re:
            localctx.exception = re
            self._errHandler.reportError(self, re)
            self._errHandler.recover(self, re)
        finally:
            self.exitRule()
        return localctx





