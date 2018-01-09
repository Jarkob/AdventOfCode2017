using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var Commands = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day8/Day8/Day8.txt");

            // Test
            //Commands = null;
            //Commands = new string[] { "b inc 5 if a > 1", "a inc 1 if b < 5", "c dec -10 if a >= 1", "c inc -20 if c == 10" };

            var Registers = new List<Tuple<string, int>>();

            // For Part2
            int HightestValueEverHeld = 0;

            foreach(var Command in Commands) {
                // Command formatieren
                var CommandParts = Command.Split(' ');
                string NewRegister = CommandParts[0];

                // Prüfen ob Register bereits existiert
                bool RegisterExists = false;
                foreach(var Register in Registers) {
                    if(Register.Item1 == NewRegister) {
                        RegisterExists = true;
                        break;
                    }
                }

                // Wenn nicht existiert anlegen und Wert auf null
                if(!RegisterExists) {
                    Registers.Add(new Tuple<string, int>(NewRegister, 0));
                }

                // Es muss auch geprüft werden, ob das Register in der Bedingung schon existiert
                NewRegister = CommandParts[4];
                RegisterExists = false;
                foreach (var Register in Registers)
                {
                    if (Register.Item1 == NewRegister)
                    {
                        RegisterExists = true;
                        break;
                    }
                }

                if (!RegisterExists)
                {
                    Registers.Add(new Tuple<string, int>(NewRegister, 0));
                }

                // Dann Bedingung prüfen
                if(CommandParts[3] != "if") {
                    throw new Exception("Die Bedingung ist nicht if...");
                }

                // Richtiges Registerelement finden
                int RegisterIndex = -1;
                for (int i = 0; i < Registers.Count; i++) {
                    if(Registers[i].Item1 == CommandParts[4]) {
                        RegisterIndex = i;
                        break;
                    }
                }

                bool ConditionFulfilled;
                int LastPart = Convert.ToInt32(CommandParts[6]);
                switch(CommandParts[5]) {
                    case ">":
                        ConditionFulfilled = Registers[RegisterIndex].Item2 > LastPart;
                        break;
                    case "<":
                        ConditionFulfilled = Registers[RegisterIndex].Item2 < LastPart;
                        break;
                    case "==":
                        ConditionFulfilled = Registers[RegisterIndex].Item2 == LastPart;
                        break;
                    case "!=":
                        ConditionFulfilled = Registers[RegisterIndex].Item2 != LastPart;
                        break;
                    case "<=":
                        ConditionFulfilled = Registers[RegisterIndex].Item2 <= LastPart;
                        break;
                    case ">=":
                        ConditionFulfilled = Registers[RegisterIndex].Item2 >= LastPart;
                        break;
                    default:
                        throw new Exception("Ungültige Verknüpfung in der Bedingung");
                }


                // Wenn Bedingung ausführen

                // Registerindex muss neu gesetzt werden
                RegisterIndex = -1;
                for (int i = 0; i < Registers.Count; i++)
                {
                    if (Registers[i].Item1 == CommandParts[0])
                    {
                        RegisterIndex = i;
                        break;
                    }
                }

                int OldValue = Registers[RegisterIndex].Item2;
                int ChangeValue = Convert.ToInt32(CommandParts[2]);
                if(ConditionFulfilled) {
                    switch(CommandParts[1]) {
                        case "inc":
                            Registers[RegisterIndex] = new Tuple<string, int>(CommandParts[0], OldValue += ChangeValue);
                            break;
                        case "dec":
                            Registers[RegisterIndex] = new Tuple<string, int>(CommandParts[0], OldValue -= ChangeValue);
                            break;
                        default:
                            throw new Exception("Unbekannte Anweisung");
                    }

                    // For Part2
                    if(Registers[RegisterIndex].Item2 > HightestValueEverHeld) {
                        HightestValueEverHeld = Registers[RegisterIndex].Item2;
                    }
                }
            }

            // Welches ist der größte Wert im Register?
            int BiggestValue = Registers[0].Item2;
            for (int i = 1; i < Registers.Count; i++) {
                if(Registers[i].Item2 > BiggestValue) {
                    BiggestValue = Registers[i].Item2;
                }
            }

            Console.WriteLine("Highest value in the end: "+ BiggestValue);
            Console.WriteLine("Highest value ever held: "+ HightestValueEverHeld);
            // 4364 is wrong
            // 6611
            // Part2 6619
        }
    }
}
