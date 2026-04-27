using modul8_103082400039;
using System;

class Program
{
    static void Main()
    {
        var config = BankTransferConfig.LoadConfig();

        // INPUT
        if (config.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int amount = int.Parse(Console.ReadLine());

        // HITUNG BIAYA
        int fee;
        if (amount <= config.transfer.threshold)
        {
            fee = config.transfer.low_fee;
        }
        else
        {
            fee = config.transfer.high_fee;
        }

        int total = amount + fee;

        // OUTPUT BIAYA
        if (config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
        }

        // PILIH METODE
        if (config.lang == "en")
        {
            Console.WriteLine("Select transfer method:");
        }
        else
        {
            Console.WriteLine("Pilih metode transfer:");
        }

        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }

        Console.ReadLine(); // input metode (ga dipakai logika)

        // KONFIRMASI
        if (config.lang == "en")
        {
            Console.Write($"Please type \"{config.confirmation.en}\" to confirm the transaction: ");
        }
        else
        {
            Console.Write($"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi: ");
        }

        string confirm = Console.ReadLine();

        // HASIL
        if ((config.lang == "en" && confirm == config.confirmation.en) ||
            (config.lang == "id" && confirm == config.confirmation.id))
        {
            if (config.lang == "en")
                Console.WriteLine("The transfer is completed");
            else
                Console.WriteLine("Proses transfer berhasil");
        }
        else
        {
            if (config.lang == "en")
                Console.WriteLine("Transfer is cancelled");
            else
                Console.WriteLine("Transfer dibatalkan");
        }
    }
}