using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;




namespace Rextester
{
	class MainClass
	{



		public abstract class Automovil
		{
			protected string modelo;
			protected string color;
			protected int potencia;
			protected double espacio;
			public Automovil(string modelo, string color, int
				potencia, double espacio)
			{
				this.modelo = modelo;
				this.color = color;
				this.potencia = potencia;
				this.espacio = espacio;
			}
			public abstract void mostrarCaracteristicas();
		}


		public class AutomovilElectricidad : Automovil
		{
			public AutomovilElectricidad(string modelo, string
				color, int potencia, double espacio) : base(modelo,
					color, potencia, espacio){}
			public override void mostrarCaracteristicas()
			{
				Console.WriteLine(
					"Automóvil eléctrico de modelo: " + modelo +
					" de color: " + color + " de potencia: " +
					potencia + " de espacio: " + espacio);
			}
		}


		public class AutomovilGasolina : Automovil
		{
			public AutomovilGasolina(string modelo, string
				color, int potencia, double espacio) : base(modelo,
					color, potencia, espacio){}
			public override void mostrarCaracteristicas()
			{
				Console.WriteLine(
					"Automóvil de gasolina de modelo: " + modelo +
					" de color: " + color + " de potencia: " +
					potencia + " de espacio: " + espacio);
			}
		}



		public abstract class Scooter
		{
			protected string modelo;
			protected string color;
			protected int potencia;
			public Scooter(string modelo, string color, int
				potencia)
			{
				this.modelo = modelo;
				this.color = color;
				this.potencia = potencia;
			}
			public abstract void mostrarCaracteristicas();
		}


		public class ScooterElectricidad : Scooter
		{
			public ScooterElectricidad(string modelo, string color,
				int potencia) : base(modelo, color, potencia){}
			public override void mostrarCaracteristicas()
			{
				Console.WriteLine("Scooter eléctrica de modelo: " +
					modelo + " de color: " + color +
					" de potencia: " + potencia);
			}
		}


		public class ScooterGasolina : Scooter
		{
			public ScooterGasolina(string modelo, string color,
				int potencia) : base(modelo, color, potencia){}
			public override void mostrarCaracteristicas()
			{
				Console.WriteLine("Scooter eléctrica de modelo: " +
					modelo + " de color: " + color +
					" de potencia: " + potencia);
			}
		}


		public interface FabricaVehiculo
		{
			Automovil creaAutomovil(string modelo, string color,
				int potencia, double espacio); 
			Scooter creaScooter(string modelo, string color, int
				potencia);
		}

		public class FabricaVehiculoElectricidad : FabricaVehiculo
		{
			public Automovil creaAutomovil(string modelo, string
				color, int potencia, double espacio)
			{
				return new AutomovilElectricidad(modelo, color,
					potencia, espacio);
			}
			public Scooter creaScooter(string modelo, string
				color, int potencia)
			{
				return new ScooterElectricidad(modelo, color,
					potencia);
			}
		}


		public class FabricaVehiculoGasolina : FabricaVehiculo
		{
			public Automovil creaAutomovil(string modelo, string
				color, int potencia, double espacio)
			{
				return new AutomovilGasolina(modelo, color,
					potencia, espacio);
			}
			public Scooter creaScooter(string modelo, string
				color, int potencia)
			{
				return new ScooterGasolina(modelo, color, potencia);
			}
		}


		public class Catalogo
		{
			public static int nAutos = 3;
			public static int nScooters = 2;






			static void Main(string[] args)
			{
				FabricaVehiculo fabrica;
				Automovil[] autos = new Automovil[nAutos];
				Scooter[] scooters = new Scooter[nScooters];
				Console.WriteLine("Desea utilizar " +
					"vehículos eléctricos (1) o a gasolina (2):");
				string eleccion = Console.ReadLine();
				if (eleccion == "1") 
				{
					fabrica = new FabricaVehiculoElectricidad();
				}
				else
				{
					fabrica = new FabricaVehiculoGasolina();
				}
				for (int index = 0; index < nAutos; index++)
					autos[index] = fabrica.creaAutomovil("estándar",
						"amarillo", 6+index, 3.2);
				for (int index = 0; index < nScooters; index++)
					scooters[index] = fabrica.creaScooter("clásico",
						"rojo", 2+index);
				foreach (Automovil auto in autos)
					auto.mostrarCaracteristicas();
				foreach (Scooter scooter in scooters)
					scooter.mostrarCaracteristicas();
			}}}


}

