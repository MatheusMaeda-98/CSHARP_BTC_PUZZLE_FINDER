using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Security.Cryptography;
using NBitcoin;

// Limita o uso da CPU (opcional, pode usar apenas um núcleo se preferir)
SetProcessAffinity(1);

// Lista de endereços públicos do puzzle
var targetAddresses = new List<string>
        {
            "1BY8GQbnueYofwSuFAT3USAhGjPrkxDdW9",
            "1MVDYgVaSN6iKKEsbzRUAYFrYJadLYZvvZ",
            "119vkiEajfhuZ8bs8Zu2jgmC6oqZbWqhxhG",
            "1PWo3JeB9jrGwfHDNpdGK54CRas7fsVzXU",
            "1JTK7s9YVYywfm5XUH7RNhHJH1LshCaRFR",
            "12VVRNPi4SJqUTsp6FmqDqY5sGosDtysn4",
            "1DJh2eHFYQfACPmrvpyWc8MSTYKh7w9eRF",
            "1FWGcVDK3JGzCC3WtkYetULPszMaK2Jksv",
            "1Bxk4CQdqL9p22JEtDfdXMsng1XacifUtE",
            "15qF6X51huDjqTmF9BJgxXdt1xcj46Jmhb",
            "1ARk8HWJMn8js8tQmGUJeQHjSE7KRkn2t8",
            "15qsCm78whspNQFydGJQk5rexzxTQopnHZ",
            "13zYrYhhJxp6Ui1VV7pqa5WDhNWM45ARAC",
            "14MdEb4eFcT3MVG5sPFG4jGLuHJSnt1Dk2",
            "1CMq3SvFcVEcpLMuuH8PUcNiqsK1oicG2D",
            "1K3x5L6G57Y494fDqBfrojD28UJv4s5JcK",
            "1PxH3K1Shdjb7gSEoTX7UPDZ6SH4qGPrvq",
            "16AbnZjZZipwHMkYKBSfswGWKDmXHjEpSf",
            "19QciEHbGVNY4hrhfKXmcBBCrJSBZ6TaVt",
            "1EzVHtmbN4fs4MiNk3ppEnKKhsmXYJ4s74",
            "1AE8NzzgKE7Yhz7BWtAcAAxiFMbPo82NB5",
            "17Q7tuG2JwFFU9rXVj3uZqRtioH3mx2Jad",
            "1K6xGMUbs6ZTXBnhw1pippqwK6wjBWtNpL",
            "15ANYzzCp5BFHcCnVFzXqyibpzgPLWaD8b",
            "18ywPwj39nGjqBrQJSzZVq2izR12MDpDr8",
            "1CaBVPrwUxbQYYswu32w7Mj4HR4maNoJSX",
            "1JWnE6p6UN7ZJBN7TtcbNDoRcjFtuDWoNL",
            "1CKCVdbDJasYmhswB6HKZHEAnNaDpK7W4n",
            "1PXv28YxmYMaB8zxrKeZBW8dt2HK7RkRPX",
            "1AcAmB6jmtU6AiEcXkmiNE9TNVPsj9DULf",
            "1EQJvpsmhazYCcKX5Au6AZmZKRnzarMVZu",
            "1AE8NzzgKE7Yhz7BWtAcAAxiFMbPo82NB5",
            "17Q7tuG2JwFFU9rXVj3uZqRtioH3mx2Jad",
            "1K6xGMUbs6ZTXBnhw1pippqwK6wjBWtNpL",
            "15ANYzzCp5BFHcCnVFzXqyibpzgPLWaD8b",
            "18ywPwj39nGjqBrQJSzZVq2izR12MDpDr8",
            "1CaBVPrwUxbQYYswu32w7Mj4HR4maNoJSX",
            "1JWnE6p6UN7ZJBN7TtcbNDoRcjFtuDWoNL",
            "18KsfuHuzQaBTNLASyj15hy4LuqPUo1FNB",
            "15EJFC5ZTs9nhsdvSUeBXjLAuYq3SWaxTc",
            "1HB1iKUqeffnVsvQsbpC6dNi1XKbyNuqao",
            "1GvgAXVCbA8FBjXfWiAms4ytFeJcKsoyhL",
            "1824ZJQ7nKJ9QFTRBqn7z7dHV5EGpzUpH3",
            "18A7NA9FTsnJxWgkoFfPAFbQzuQxpRtCos",
            "1NeGn21dUDDeqFQ63xb2SpgUuXuBLA4WT4",
            "174SNxfqpdMGYy5YQcfLbSTK3MRNZEePoy",
            "1MnJ6hdhvK37VLmqcdEwqC3iFxyWH2PHUV",
            "1KNRfGWw7Q9Rmwsc6NT5zsdvEb9M2Wkj5Z",
            "1PJZPzvGX19a7twf5HyD2VvNiPdHLzm9F6",
            "1GuBBhf61rnvRe4K8zu8vdQB3kHzwFqSy7",
            "1GDSuiThEV64c166LUFC9uDcVdGjqkxKyh",
            "1Me3ASYt5JCTAK2XaC32RMeH34PdprrfDx",
            "1CdufMQL892A69KXgv6UNBD17ywWqYpKut",
            "1BkkGsX9ZM6iwL3zbqs7HWBV7SvosR6m8N",
            "1AWCLZAjKbV1P7AHvaPNCKiB7ZWVDMxFiz",
            "1G6EFyBRU86sThN3SSt3GrHu1sA7w7nzi4",
            "1MZ2L1gFrCtkkn6DnTT2e4PFUTHw9gNwaj",
            "1Hz3uv3nNZzBVMXLGadCucgjiCs5W9vaGz",
            "16zRPnT8znwq42q7XeMkZUhb1bKqgRogyy",
            "1KrU4dHE5WrW8rhWDsTRjR21r8t3dsrS3R",
            "17uDfp5r4n441xkgLFmhNoSW1KWp6xVLD",
            "13A3JrvXmvg5w9XGvyyR4JEJqiLz8ZySY3",
            "16RGFo6hjq9ym6Pj7N5H7L1NR1rVPJyw2v",
            "1UDHPdovvR985NrWSkdWQDEQ1xuRiTALq",
            "15nf31J46iLuK1ZkTnqHo7WgN5cARFK3RA",
            "1Ab4vzG6wEQBDNQM1B2bvUz4fqXXdFk2WT",
            "1Fz63c775VV9fNyj25d9Xfw3YHE6sKCxbt",
            "1QKBaU6WAeycb3DbKbLBkX7vJiaS8r42Xo",
            "1CD91Vm97mLQvXhrnoMChhJx4TP9MaQkJo",
            "15MnK2jXPqTMURX4xC3h4mAZxyCcaWWEDD",
            "13N66gCzWWHEZBxhVxG18P8wyjEWF9Yoi1",
            "1NevxKDYuDcCh1ZMMi6ftmWwGrZKC6j7Ux",
            "19GpszRNUej5yYqxXoLnbZWKew3KdVLkXg",
            "1M7ipcdYHey2Y5RZM34MBbpugghmjaV89P",
            "18aNhurEAJsw6BAgtANpexk5ob1aGTwSeL",
            "1FwZXt6EpRT7Fkndzv6K4b4DFoT4trbMrV",
            "1CXvTzR6qv8wJ7eprzUKeWxyGcHwDYP1i2",
            "1MUJSJYtGPVGkBCTqGspnxyHahpt5Te8jy",
            "13Q84TNNvgcL3HJiqQPvyBb9m4hxjS3jkV",
            "1LuUHyrQr8PKSvbcY1v1PiuGuqFjWpDumN",
            "1NgVmsCCJaKLzGyKLFJfVequnFW9ZvnMLN",
            "1AoeP37TmHdFh8uN72fu9AqgtLrUwcv2wJ",
            "1FTpAbQa4h8trvhQXjXnmNhqdiGBd1oraE",
            "14JHoRAdmJg3XR4RjMDh6Wed6ft6hzbQe9",
            "19z6waranEf8CcP8FqNgdwUe1QRxvUNKBG",
            "14u4nA5sugaswb6SZgn5av2vuChdMnD9E5",
            "1NBC8uXJy1GiJ6drkiZa1WuKn51ps7EPTv"
        };

int attempts = 0;
Console.WriteLine("Iniciando o BTC Puzzle...");

while (true)
{
    attempts++;

    // Gera uma chave privada aleatória
    string privateKeyHex = GeneratePrivateKeyWithLeadingZeros();
    //Console.WriteLine($"Generated Private Key: {privateKeyHex}");
    var privateKey = new Key(NBitcoin.DataEncoders.Encoders.Hex.DecodeData(privateKeyHex));
    // Deriva o endereço público
    BitcoinAddress publicKeyAddress = privateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

    // Feedback após 1 milhão de tentativas
    if (attempts % 1_000_000 == 0)
    {
        Console.WriteLine($"Tentativas realizadas: {attempts}...");
    }

    // Verifica se corresponde a algum endereço na lista
    if (targetAddresses.Contains(publicKeyAddress.ToString()))
    {
        Console.WriteLine($"\nChave privada encontrada após {attempts} tentativas!");
        Console.WriteLine($"Chave privada (hex): {privateKeyHex}");
        Console.WriteLine($"Endereço correspondente: {publicKeyAddress}");
        break;
    }
}

// Método para limitar o uso da CPU
void SetProcessAffinity(int cores)
{
    try
    {
        var process = System.Diagnostics.Process.GetCurrentProcess();
        long affinityMask = (1 << cores) - 1; // Define o número de núcleos a usar
        process.ProcessorAffinity = (IntPtr)affinityMask;
        Console.WriteLine($"Afinidade de CPU definida para {cores} núcleo(s).");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao configurar afinidade de CPU: " + ex.Message);
    }
}

string GeneratePrivateKeyWithLeadingZeros()
{
    int leadingZeros = GetWeightedRandomZeros(); // Get a random number of zeros between 42 and 47 with higher probability for 47.
    int totalLength = 64; // Total length of the private key.

    byte[] randomBytes = new byte[totalLength];
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(randomBytes);
    }

    string randomHex = string.Concat(randomBytes.Select(b => b.ToString("x2")));

    // Ensure the key is 64 characters by truncating excess characters.
    randomHex = randomHex.Substring(0, totalLength - leadingZeros);

    // Add leading zeros.
    string privateKeyHex = new string('0', leadingZeros) + randomHex;

    return privateKeyHex;
}
int GetWeightedRandomZeros()
{
    // Define weights for each number of zeros (42-47).
    int[] zeros = { 43, 44, 45, 46, 47 };
    double[] weights = { 0.05, 0.15, 0.2, 0.25, 0.35 }; // Higher probability for 47.

    // Generate a random number weighted by the probabilities.
    double randomValue = RandomNumber();
    double cumulative = 0.0;

    for (int i = 0; i < zeros.Length; i++)
    {
        cumulative += weights[i];
        if (randomValue <= cumulative)
        {
            return zeros[i];
        }
    }

    return zeros.Last(); // Default to the last value (47) if no match.

}
double RandomNumber()
{
    // Generate a random double between 0 and 1.
    using (var rng = RandomNumberGenerator.Create())
    {
        byte[] randomBytes = new byte[4];
        rng.GetBytes(randomBytes);
        return BitConverter.ToUInt32(randomBytes, 0) / (double)uint.MaxValue;
    }
}
