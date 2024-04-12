using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarytree
{
    internal class ArbolDecision
    {
        public string pregunta;
        public ArbolDecision si;
        public ArbolDecision no;
        public string respuesta;

        public ArbolDecision(string pregunta)
        {
            this.pregunta = pregunta;
            si = null;
            no = null;
            respuesta = null;
        }
        public ArbolDecision()
        {
        }

        // Clase para el árbol de decisión
        public class DecisionTree
        {
            private ArbolDecision root;

            public DecisionTree(ArbolDecision rootNode)
            {
                root = rootNode;
            }

            // Método para realizar la evaluación de la decisión
            public string EvaluarDecision()
            {
                ArbolDecision current = root;

                while (current != null)
                {
                    Console.WriteLine(current.pregunta);
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "si")
                    {
                        if (current.si != null)
                        {
                            current = current.si;
                        }
                        else
                        {
                            return current.respuesta;
                        }
                    }
                    else if (respuesta == "no")
                    {
                        if (current.no != null)
                        {
                            current = current.no;
                        }
                        else
                        {
                            return current.respuesta;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Respuesta inválida. Por favor, responda 'si' o 'no'.");
                    }
                }

                return null;
            }

        }



        public void jugar()
        {
            ArbolDecision root = new ArbolDecision("¿Es el problema fácil de solucionar?");
            root.si = new ArbolDecision("¿Puedes resolverlo tú mismo?");
            root.si = new ArbolDecision("¿demasiado facil?");
            root.si = new ArbolDecision("¿si es facil?");
            root.no = new ArbolDecision("¿tienes donde buscar informacion?");
            root.si.si = new ArbolDecision("Hazlo tú mismo.");
            root.si.no = new ArbolDecision("¿Puedes pedir ayuda?");
            root.si.no.si = new ArbolDecision("Pide ayuda a un compañero.");
            root.si.no.no = new ArbolDecision("¿Es una emergencia?");
            root.si.no.no.si = new ArbolDecision("Pide ayuda a un supervisor.");
            root.si.no.no.no = new ArbolDecision("Encuentra una solución temporal.");

            DecisionTree tree = new DecisionTree(root);

            // Evaluar el árbol de decisión
            Console.WriteLine("Responde 'si' o 'no' a las siguientes preguntas:");
            string mejorOpcion = tree.EvaluarDecision();
            Console.WriteLine($"La mejor opción es: {mejorOpcion}");
        }
    }
}
