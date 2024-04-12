using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarytree
{
    internal class DecisionTreeNode
    {
        public string pregunta;
        public DecisionTreeNode si;
        public DecisionTreeNode no;
        public string respuesta;

        public List<string> respuestas; // Lista de respuestas posibles

        public DecisionTreeNode(string pregunta)
        {
            this.pregunta = pregunta;
            si = null;
            no = null;
            respuesta = null;
            respuestas = new List<string>(); // Inicializar la lista de respuestas
        }
        public DecisionTreeNode() { }


        // Clase para el árbol de decisión
        public class DecisionTreeEval
        {
            private DecisionTreeNode root;

            public DecisionTreeEval(DecisionTreeNode rootNode)
            {
                root = rootNode;
            }

            // Método para realizar la evaluación de la decisión
            public string EvaluarDecision()
            {
                DecisionTreeNode current = root;

                while (current != null)
                {
                    Console.WriteLine(current.pregunta);

                    // Si hay más de una respuesta posible, selecciona aleatoriamente
                    string respuesta;
                    if (current.respuestas.Count > 0)
                    {
                        Random rnd = new Random();
                        int index = rnd.Next(current.respuestas.Count);
                        respuesta = current.respuestas[index];
                    }
                    else
                    {
                        respuesta = Console.ReadLine().ToLower();
                    }

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
            // Crear el árbol de decisión
            DecisionTreeNode root = new DecisionTreeNode("¿Es el problema fácil de solucionar?");
            root.si = new DecisionTreeNode("¿Puedes resolverlo tú mismo?");
            root.si.respuestas.Add("Hazlo tú mismo");
            root.si.respuestas.Add("Buena suerte");
            root.no = new DecisionTreeNode("¿Puedes pedir ayuda?");
            root.no.si = new DecisionTreeNode("Pide ayuda a un compañero.");
            root.no.no = new DecisionTreeNode("¿Es una emergencia?");
            root.no.no.si = new DecisionTreeNode("Pide ayuda a un supervisor.");
            root.no.no.no = new DecisionTreeNode("Encuentra una solución temporal.");

            DecisionTreeEval tree = new DecisionTreeEval(root);

            // Evaluar el árbol de decisión
            Console.WriteLine("Responde 'si' o 'no' a las siguientes preguntas:");
            string mejorOpcion = tree.EvaluarDecision();
            Console.WriteLine($"La mejor opción es: {mejorOpcion}");
        }

    }
}