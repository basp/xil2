grammar Joy;

cycle                   :   (term | simpleDefinition) '.'
                        ;

simpleDefinition        :   atomicSymbol '==' term
                        ;

term                    :   factor*
                        ;

factor                  :   atomicSymbol        
                        |   booleanConstant     
                        |   integerConstant
                        |   floatConstant
                        |   characterConstant
                        |   stringConstant
                        |   setLiteral
                        |   quotationLiteral
                        ;

setLiteral              :   '{' (characterConstant | integerConstant)* '}'
                        ;

quotationLiteral        :   '[' term ']'
                        ;

atomicSymbol            :   SYMBOL ;

booleanConstant         :   BOOL ;

integerConstant         :   INT ;

floatConstant           :   FLOAT ;

characterConstant       :   CHAR ;

stringConstant          :   STRING ;

BOOL                    :   'true' | 'false' ;

INT                     :   ('-')? DIGIT+ ;

HEX                     :   '0' ('x' | 'X') HEXDIGIT+ ;

FLOAT                   :   ('-')? DIGIT+ '.' DIGIT+ EXP?
                        |   ('-')? DIGIT+ EXP?
                        ;

CHAR                    :   '\'' LETTER ;

STRING                  :   '"' (ESC | ~[\\"])*? '"' ;

SYMBOL                  :   SYMBOL_START_CHAR SYMBOL_CHAR* ;

SINGLE_LINE_COMMENT     :   '#' ~[\r\n\f]* -> skip ;
MULTI_LINE_COMMENT      :   '(*' .*? '*)' -> skip ;

WS                      :   [ \t\r\n] -> skip ;

fragment SYMBOL_START_CHAR
                        :   '!'..'-'
                        |   '/'
                        |   ':'
                        |   '<'..'@'
                        |   'A'..'Z'
                        |   '^'..'`'
                        |   'a'..'z'
                        |   '|'
                        |   '~'
                        ;

fragment SYMBOL_CHAR    :   SYMBOL_START_CHAR
                        |   '0'..'9'
                        ;

fragment HEXDIGIT       :   [0-9a-fA-F] ;
fragment EXP            :   ('E' | 'e') ('+' | '-')? INT ;
fragment LETTER         :   [a-zA-Z] ;
fragment DIGIT          :   [0-9] ;
fragment ESC            :   '\\' ["'\\ntbrf] ;