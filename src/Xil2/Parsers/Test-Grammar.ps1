param(
    [string] $Name = "Test3", 
    [string] $Root = "expression",
    [string] $Mode = "gui"
)

$tool = "org.antlr.v4.Tool"
$grun = "org.antlr.v4.gui.TestRig"
$file = $("$Name.g4")
$out = ".\out"

Push-Location
java $tool $file -o $out
Set-Location $out
javac *.java
java $grun $Name $Root -$Mode
Pop-Location