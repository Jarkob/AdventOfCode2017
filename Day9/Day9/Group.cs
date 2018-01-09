using System;
using System.Collections.Generic;
namespace Day9
{
    public class Group
    {
        public Group(string stream)
        {
            Subgroups = new List<Group>();

            // Hier müssen alle Gruppen herausgelesen werden
            for (int i = 0; i < stream.Length; i++)
            {
                if (stream[i] == '!')
                {
                    i++;
                    continue;
                }

                if (stream[i] == '{')
                {
                    // Neue Schleife
                    int Subgroups = 0;
                    int j = i + 1;
                    while (true)
                    {
                        if(stream[j] == '!') {
                            j++;
                            continue;
                        }

                        switch(stream[j]) {
                            case '{':
                                Subgroups++;
                                break;
                            case '}':
                                Subgroups--;
                                break;
                            default:
                                throw new Exception("Ein unbekanntes Zei"); // Vermutlich ist diese Klasse obsolet
                        }

                        j++;
                    }
                }
            }
        }

        List<Group> Subgroups;
    }
}
