// Generated from Joy.g4 by ANTLR 4.12.0
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link JoyParser}.
 */
public interface JoyListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link JoyParser#cycle}.
	 * @param ctx the parse tree
	 */
	void enterCycle(JoyParser.CycleContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#cycle}.
	 * @param ctx the parse tree
	 */
	void exitCycle(JoyParser.CycleContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#simpleDefinition}.
	 * @param ctx the parse tree
	 */
	void enterSimpleDefinition(JoyParser.SimpleDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#simpleDefinition}.
	 * @param ctx the parse tree
	 */
	void exitSimpleDefinition(JoyParser.SimpleDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#term}.
	 * @param ctx the parse tree
	 */
	void enterTerm(JoyParser.TermContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#term}.
	 * @param ctx the parse tree
	 */
	void exitTerm(JoyParser.TermContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#factor}.
	 * @param ctx the parse tree
	 */
	void enterFactor(JoyParser.FactorContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#factor}.
	 * @param ctx the parse tree
	 */
	void exitFactor(JoyParser.FactorContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#setLiteral}.
	 * @param ctx the parse tree
	 */
	void enterSetLiteral(JoyParser.SetLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#setLiteral}.
	 * @param ctx the parse tree
	 */
	void exitSetLiteral(JoyParser.SetLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#quotationLiteral}.
	 * @param ctx the parse tree
	 */
	void enterQuotationLiteral(JoyParser.QuotationLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#quotationLiteral}.
	 * @param ctx the parse tree
	 */
	void exitQuotationLiteral(JoyParser.QuotationLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#atomicSymbol}.
	 * @param ctx the parse tree
	 */
	void enterAtomicSymbol(JoyParser.AtomicSymbolContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#atomicSymbol}.
	 * @param ctx the parse tree
	 */
	void exitAtomicSymbol(JoyParser.AtomicSymbolContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#booleanConstant}.
	 * @param ctx the parse tree
	 */
	void enterBooleanConstant(JoyParser.BooleanConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#booleanConstant}.
	 * @param ctx the parse tree
	 */
	void exitBooleanConstant(JoyParser.BooleanConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#integerConstant}.
	 * @param ctx the parse tree
	 */
	void enterIntegerConstant(JoyParser.IntegerConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#integerConstant}.
	 * @param ctx the parse tree
	 */
	void exitIntegerConstant(JoyParser.IntegerConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#floatConstant}.
	 * @param ctx the parse tree
	 */
	void enterFloatConstant(JoyParser.FloatConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#floatConstant}.
	 * @param ctx the parse tree
	 */
	void exitFloatConstant(JoyParser.FloatConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#characterConstant}.
	 * @param ctx the parse tree
	 */
	void enterCharacterConstant(JoyParser.CharacterConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#characterConstant}.
	 * @param ctx the parse tree
	 */
	void exitCharacterConstant(JoyParser.CharacterConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link JoyParser#stringConstant}.
	 * @param ctx the parse tree
	 */
	void enterStringConstant(JoyParser.StringConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link JoyParser#stringConstant}.
	 * @param ctx the parse tree
	 */
	void exitStringConstant(JoyParser.StringConstantContext ctx);
}