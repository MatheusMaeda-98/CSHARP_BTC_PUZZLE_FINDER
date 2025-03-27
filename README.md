# CSHARP_BTC_PUZZLE_FINDER

Este é uma ferramenta desenvolvida na tentativa de encontrar soluções dos btcs puzzles.
Para usar o programa abra o arquivo Program.cs pelo vscode e execute.

Em SetProcessAffinity(1); você pode definir a quantidade de cores da cpu utilizado para a procura, padrão setado para 1 core apenas.
Em var targetAddresses = new List<string> no código pode visualizar, atualizar, testar e modificar todas as chaves a serem procuradas.
Após 1 milhão de tentativas ele vai te dar um feedback no console.

**Como funciona o código**

o código vai gerar um código hex aleatório com um certo números de zeros a esquerda (setados padrão a gerar entre 43 até 47 zeros na frente)
o código hex aleatório vai gerar mais chaves com 47 zeros a esquerda para priorizar chaves estatisticamente mais facil de serem encontradas;
após isso, será comparada com as chaves presentes em "targetAddresses"
Voce pode mudar a quantidades de zeros e os pesos de procura em "int GetWeightedRandomZeros()"
Voce pode mudar a chaves a serem comparadas em "targetAddresse"

