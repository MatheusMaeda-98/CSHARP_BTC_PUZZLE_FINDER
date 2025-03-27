# CSHARP_BTC_PUZZLE_FINDER - PT-BR

Este é uma ferramenta desenvolvida na tentativa de encontrar soluções dos btcs puzzles.
Para usar o programa abra o arquivo Program.cs pelo vscode e execute.

Em SetProcessAffinity(1); você pode definir a quantidade de cores da cpu utilizado para a procura, padrão setado para 1 core apenas.
Em var targetAddresses = new List<string> no código pode visualizar, atualizar, testar e modificar todas as chaves a serem procuradas.
Após 1 milhão de tentativas ele vai te dar um feedback no console.

**Como funciona o código**

- O código vai gerar um código hex aleatório com um certo números de zeros a esquerda (setados padrão a gerar entre 43 até 47 zeros na frente)
- O código hex aleatório vai gerar mais chaves com 47 zeros a esquerda para priorizar chaves estatisticamente mais facil de serem encontradas;
após isso, será comparada com as chaves presentes em "targetAddresses"
- Voce pode mudar a quantidades de zeros e os pesos de procura em "int GetWeightedRandomZeros()"
- Voce pode mudar a chaves a serem comparadas em "targetAddresse"

# CSHARP_BTC_PUZZLE_FINDER - EN-US
This is a tool developed in an attempt to find solutions for BTC puzzles. To use the program, open the Program.cs file in VS Code and run it.

In SetProcessAffinity(1);, you can define the number of CPU cores used for the search, with the default set to only 1 core. In var targetAddresses = new List<string> in the code, you can view, update, test, and modify all the keys to be searched. After 1 million attempts, it will give you feedback in the console.

**How the Code Works**

- The code generates a random hex code with a certain number of leading zeros (set by default to generate between 43 and 47 leading zeros).

- The random hex code will generate more keys with 47 leading zeros to prioritize keys statistically easier to find; afterward, it will compare them with the keys present in targetAddresses.

- You can change the number of zeros and the search weights in int GetWeightedRandomZeros().

- You can modify the keys to be compared in targetAddresses.

