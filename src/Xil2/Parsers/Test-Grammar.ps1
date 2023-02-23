param(
    [string] $Name = "Xil", 
    [string] $Root = "cycle",
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
