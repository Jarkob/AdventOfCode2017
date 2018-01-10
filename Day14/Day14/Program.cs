using System;
					
public class Program
{
	public static void Main()
	{
		//Part1();
		Part2();
	}
	
	
	public static void Part2()
	{
		string Input = "amgozmfv";
		
		
		// Disc erstellen
		int[][] Disc = new int[128][];
		for(int i = 0; i < Disc.Length; i++)
		{
			Disc[i] = new int[128];
		}
		
		
		// Sachen berechnen
		string TempInput;
		string KnotHash;
		
		for(int i = 0; i < Disc.Length; i++)
		{
			TempInput = Input + "-" + i;
			
			KnotHash = GetKnotHash(TempInput);
			
			// Jetzt hex in bin umwandeln
			string Hex;
			string Bin = "";
			for(int j = 0; j < KnotHash.Length; j += 2)
			{
				Hex = KnotHash[j].ToString() + KnotHash[j + 1].ToString();
				
				Bin += hex2binary(Hex);
			}
			
			// Jetzt Bin auf die Disc schreiben
			for(int k = 0; k < Bin.Length; k++)
			{
				Disc[i][k] = Bin[k] == 1 ? 1 : 0;
			}
		}
		
		// Disc ist fertig beschrieben, jetzt müssen adjacent squares berechnet werden
	}
	
	
	public static void Part1()
	{
		string Input = "amgozmfv";
		
		int UsedSquares = 0;
		
		
		// Sachen berechnen
		string TempInput;
		string KnotHash;
		
		for(int i = 0; i < 128; i++)
		{
			TempInput = Input + "-" + i;
			
			KnotHash = GetKnotHash(TempInput);
			
			// Jetzt hex in bin umwandeln
			string Hex;
			string Bin;
			for(int j = 0; j < KnotHash.Length; j += 2)
			{
				Hex = KnotHash[j].ToString() + KnotHash[j + 1].ToString();
				
				Bin = hex2binary(Hex);
				
				foreach(var element in Bin)
				{
					if(element == '1')
					{
						UsedSquares++;
					}
				}
			}
		}
		
		Console.WriteLine("Anzahl benutzte Quadrate: "+ UsedSquares);
	}
	
	
	public static string GetKnotHash(string Input)
	{	
		int[] List = new int[256];
        for (int i = 0; i < 256; i++)
        {
            List[i] = i;
		}
		
		byte[] Lengths = new byte[Input.Length + 5];
		
		for (int i = 0; i < Input.Length; i++) {
			Lengths[i] = Convert.ToByte(Input[i]);
		}
		
		// 17, 31, 73, 47, 23
		Lengths[Lengths.Length - 5] = 17;
		Lengths[Lengths.Length - 4] = 31;
		Lengths[Lengths.Length - 3] = 73;
		Lengths[Lengths.Length - 2] = 47;
		Lengths[Lengths.Length - 1] = 23;
		
		// Run rounds
		int CurrentPosition = 0;
		int SkipSize = 0;
		
		for (int j = 0; j < 64; j++)
		{
			foreach (var Length in Lengths)
			{
				Reverse(ref List, CurrentPosition, CurrentPosition + Length - 1);
				CurrentPosition += Length + SkipSize;
				while (CurrentPosition >= List.Length) // while nicht if sonst kann die SkipSize nicht beliebig groß werden, kritisch
				{
					CurrentPosition -= List.Length;
				}
				SkipSize++;
			}
		}
		
		// Sparse Hash in Dense Hash (|X|=16) umwandeln
		int[] DenseHash = new int[16];
		int k = 0;
		int l = 0;
		while(k < List.Length) {
			DenseHash[l] ^= List[k];
			k++;
			if(k % 16 == 0) {
				l++;
			}
		}
		
		// In Hex umwandeln
		// string.Format("{0:x}", decValue);
		string KnotHash = "";
		
		foreach(var element in DenseHash) {
			KnotHash += String.Format("{0:x2}", element);
		}
		
		Console.WriteLine(KnotHash);
		// e1a65bfb5a5ce39625fab5528c25a87 is wrong
		//e1a65bfb5a5ce396025fab5528c25a87
		
		return KnotHash;
	}
	
	// Ich glaube das funktioniert jetzt
	public static void Reverse(ref int[] Array, int Start, int End)
	{
		int Swap;
		
		int Steps = (End - Start) / 2;
		int Step = 0;
		
		int i = Start >= Array.Length ? Start -= Array.Length : Start;
		int j = End >= Array.Length ? End -= Array.Length : End;
		
		while(Step <= Steps) {
			// debug
			//Console.WriteLine("Log: i = {0}, j = {1}", i, j);
			Swap = Array[i];
			Array[i] = Array[j];
			Array[j] = Swap;
			
			// Indizes erhöhen
			i = i == Array.Length - 1 ? 0 : i + 1;
			j = j == 0 ? Array.Length - 1 : j - 1;
			Step++;
			
			// debug
			//Print(Array);
		}
	}
	
	private static string hex2binary(string hexvalue)
	{
		string binaryval = "";
		binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);
		return binaryval;
	}
}
