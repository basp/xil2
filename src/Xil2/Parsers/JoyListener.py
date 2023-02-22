# Generated from .\Joy.g4 by ANTLR 4.12.0
from antlr4 import *
if __name__ is not None and "." in __name__:
    from .JoyParser import JoyParser
else:
    from JoyParser import JoyParser

# This class defines a complete listener for a parse tree produced by JoyParser.
class JoyListener(ParseTreeListener):

    # Enter a parse tree produced by JoyParser#cycle.
    def enterCycle(self, ctx:JoyParser.CycleContext):
        pass

    # Exit a parse tree produced by JoyParser#cycle.
    def exitCycle(self, ctx:JoyParser.CycleContext):
        pass


    # Enter a parse tree produced by JoyParser#simpleDefinition.
    def enterSimpleDefinition(self, ctx:JoyParser.SimpleDefinitionContext):
        pass

    # Exit a parse tree produced by JoyParser#simpleDefinition.
    def exitSimpleDefinition(self, ctx:JoyParser.SimpleDefinitionContext):
        pass


    # Enter a parse tree produced by JoyParser#term.
    def enterTerm(self, ctx:JoyParser.TermContext):
        pass

    # Exit a parse tree produced by JoyParser#term.
    def exitTerm(self, ctx:JoyParser.TermContext):
        pass


    # Enter a parse tree produced by JoyParser#factor.
    def enterFactor(self, ctx:JoyParser.FactorContext):
        pass

    # Exit a parse tree produced by JoyParser#factor.
    def exitFactor(self, ctx:JoyParser.FactorContext):
        pass


    # Enter a parse tree produced by JoyParser#setLiteral.
    def enterSetLiteral(self, ctx:JoyParser.SetLiteralContext):
        pass

    # Exit a parse tree produced by JoyParser#setLiteral.
    def exitSetLiteral(self, ctx:JoyParser.SetLiteralContext):
        pass


    # Enter a parse tree produced by JoyParser#quotationLiteral.
    def enterQuotationLiteral(self, ctx:JoyParser.QuotationLiteralContext):
        pass

    # Exit a parse tree produced by JoyParser#quotationLiteral.
    def exitQuotationLiteral(self, ctx:JoyParser.QuotationLiteralContext):
        pass


    # Enter a parse tree produced by JoyParser#atomicSymbol.
    def enterAtomicSymbol(self, ctx:JoyParser.AtomicSymbolContext):
        pass

    # Exit a parse tree produced by JoyParser#atomicSymbol.
    def exitAtomicSymbol(self, ctx:JoyParser.AtomicSymbolContext):
        pass


    # Enter a parse tree produced by JoyParser#booleanConstant.
    def enterBooleanConstant(self, ctx:JoyParser.BooleanConstantContext):
        pass

    # Exit a parse tree produced by JoyParser#booleanConstant.
    def exitBooleanConstant(self, ctx:JoyParser.BooleanConstantContext):
        pass


    # Enter a parse tree produced by JoyParser#integerConstant.
    def enterIntegerConstant(self, ctx:JoyParser.IntegerConstantContext):
        pass

    # Exit a parse tree produced by JoyParser#integerConstant.
    def exitIntegerConstant(self, ctx:JoyParser.IntegerConstantContext):
        pass


    # Enter a parse tree produced by JoyParser#floatConstant.
    def enterFloatConstant(self, ctx:JoyParser.FloatConstantContext):
        pass

    # Exit a parse tree produced by JoyParser#floatConstant.
    def exitFloatConstant(self, ctx:JoyParser.FloatConstantContext):
        pass


    # Enter a parse tree produced by JoyParser#characterConstant.
    def enterCharacterConstant(self, ctx:JoyParser.CharacterConstantContext):
        pass

    # Exit a parse tree produced by JoyParser#characterConstant.
    def exitCharacterConstant(self, ctx:JoyParser.CharacterConstantContext):
        pass


    # Enter a parse tree produced by JoyParser#stringConstant.
    def enterStringConstant(self, ctx:JoyParser.StringConstantContext):
        pass

    # Exit a parse tree produced by JoyParser#stringConstant.
    def exitStringConstant(self, ctx:JoyParser.StringConstantContext):
        pass



del JoyParser