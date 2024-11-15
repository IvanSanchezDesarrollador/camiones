using System;

class Program
{
    static void Main()
    {
        //Variable boleana para intententarlo nuevamente
        bool seguirIntentando = true;  

        while (seguirIntentando)
        {
            //El vaor del Tamaño del camion debe ser mayor que 30
            int tamañoCamion;
            do
            {
                Console.Write("Tamaño del camión (debe ser mayor a 30): ");
            }
            while (!int.TryParse(Console.ReadLine(), out tamañoCamion) || tamañoCamion <= 30);  

           
            Console.Write("Cantidad de paquetes: ");
            int cantidadPaquetes = int.Parse(Console.ReadLine());

           
            int[] arrayPaquetes = new int[cantidadPaquetes];

            //Los valor de los paquetes deben ser mayores que 0
            for (int i = 0; i < cantidadPaquetes; i++)
            {
                
                int tamañoPaquete;
                do
                {
                    Console.Write($"Tamaño de paquete N° {i + 1} (debe ser mayor a 0): ");
                }
                while (!int.TryParse(Console.ReadLine(), out tamañoPaquete) || tamañoPaquete <= 0); 
                arrayPaquetes[i] = tamañoPaquete;
            }

            //Cantidad requerida del camion 
            int espacioRequerido = tamañoCamion - 30; 
            Console.Write($"Total tamaño requerido : {espacioRequerido}");
            //Varibales que alamacen el valor de los paquetes
            int paquete1 = 0, paquete2 = 0;
            //Variable indicadora, si el programa encentra un par que cumpla la condicion esta variable se encargar de escojer el paquete que tenga el numero mayor
            int maxPaquete = int.MinValue;



            for (int i = 0; i < cantidadPaquetes - 1; i++)
            {
                for (int j = i + 1; j < cantidadPaquetes; j++)
                {
                    //Encuentra todas la convinaciones
                    int sumaPaquetes = arrayPaquetes[i] + arrayPaquetes[j];

                    
                    if (sumaPaquetes == espacioRequerido)
                    {
                        //De los pares que cumplen elige aquel que tenga el numero mayor
                        int paqueteMayor = Math.Max(arrayPaquetes[i], arrayPaquetes[j]);
                        if (paqueteMayor > maxPaquete)
                        {
                            //Asignacion de valores 
                            maxPaquete = paqueteMayor;
                            paquete1 = arrayPaquetes[i]; 
                            paquete2 = arrayPaquetes[j]; 
                        }
                    }
                }
            }

            // Mostrar el resultado
            if (paquete1 != 0 && paquete2 != 0)
            {
                Console.WriteLine($"\nPaquetes seleccionados para cargar en el camión: [{paquete1}, {paquete2}]");
            }
            else
            {
                Console.WriteLine("\nNo se encontraron dos paquetes que cumplan con los requisitos.");
            }

            Console.WriteLine("\n¿Deseas realizar otro intento? (s/n): ");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta != "s")
            {
                seguirIntentando = false;
            }
        }

        // Pausar antes de cerrar la consola
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
