using System;
using System.Collections.Generic;

namespace PracticaExperimental2
{
    public class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    public class ColaAsientos
    {
        private Queue<Persona> cola;
        private int capacidadMaxima;

        public ColaAsientos(int capacidad)
        {
            capacidadMaxima = capacidad;
            cola = new Queue<Persona>();
        }

        public void AgregarPersona(Persona persona)
        {
            if (cola.Count < capacidadMaxima)
            {
                cola.Enqueue(persona);
                Console.WriteLine($"✔ {persona.Nombre} ha sido agregado a la cola.");
            }
            else
            {
                Console.WriteLine($"❌ No hay más asientos disponibles para {persona.Nombre}.");
            }
        }

        public void AsignarAsientos()
        {
            Console.WriteLine("\n🪑 Asignando asientos en orden de llegada:");
            int asiento = 1;
            while (cola.Count > 0)
            {
                Persona persona = cola.Dequeue();
                Console.WriteLine($"➡ Asiento {asiento++}: {persona.Nombre}");
            }
        }

        public void MostrarCola()
        {
            Console.WriteLine("\n📋 Personas en la cola:");
            foreach (var persona in cola)
            {
                Console.WriteLine($"- {persona.Nombre}");
            }
        }

        public void ConsultarEstado()
        {
            Console.WriteLine($"\n🔎 Total de personas en cola: {cola.Count}");
            Console.WriteLine($"🚫 Asientos disponibles: {capacidadMaxima - cola.Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ColaAsientos cola = new ColaAsientos(30);
            int opcion;

            do
            {
                Console.WriteLine("\n--- MENÚ DE ASIGNACIÓN DE ASIENTOS ---");
                Console.WriteLine("1. Agregar persona");
                Console.WriteLine("2. Mostrar personas en cola");
                Console.WriteLine("3. Asignar asientos");
                Console.WriteLine("4. Consultar estado");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("❗ Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nombre))
                        {
                            Persona persona = new Persona(nombre);
                            cola.AgregarPersona(persona);
                        }
                        else
                        {
                            Console.WriteLine("❗ El nombre no puede estar vacío.");
                        }
                        break;

                    case 2:
                        cola.MostrarCola();
                        break;

                    case 3:
                        cola.AsignarAsientos();
                        break;

                    case 4:
                        cola.ConsultarEstado();
                        break;

                    case 0:
                        Console.WriteLine("👋 Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("❗ Opción no válida.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}