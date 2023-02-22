# Generated from .\Joy.g4 by ANTLR 4.12.0
from antlr4 import *
if __name__ is not None and "." in __name__:
    from .JoyParser import JoyParser
else:
    from JoyParser import JoyParser

# This class defines a complete generic visitor for a parse tree produced by JoyParser.

class JoyVisitor(ParseTreeVisitor):

    # Visit a parse tree produced by JoyParser#cycle.
    def visitCycle(self, ctx:JoyParser.CycleContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#simpleDefinition.
    def visitSimpleDefinition(self, ctx:JoyParser.SimpleDefinitionContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#term.
    def visitTerm(self, ctx:JoyParser.TermContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#factor.
    def visitFactor(self, ctx:JoyParser.FactorContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#setLiteral.
    def visitSetLiteral(self, ctx:JoyParser.SetLiteralContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#quotationLiteral.
    def visitQuotationLiteral(self, ctx:JoyParser.QuotationLiteralContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#atomicSymbol.
    def visitAtomicSymbol(self, ctx:JoyParser.AtomicSymbolContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#booleanConstant.
    def visitBooleanConstant(self, ctx:JoyParser.BooleanConstantContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#integerConstant.
    def visitIntegerConstant(self, ctx:JoyParser.IntegerConstantContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#floatConstant.
    def visitFloatConstant(self, ctx:JoyParser.FloatConstantContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#characterConstant.
    def visitCharacterConstant(self, ctx:JoyParser.CharacterConstantContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by JoyParser#stringConstant.
    def visitStringConstant(self, ctx:JoyParser.StringConstantContext):
        return self.visitChildren(ctx)



del JoyParser