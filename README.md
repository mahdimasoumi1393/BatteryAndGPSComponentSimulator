# BatteryAndGPSComponentSimulator a Simple Vehicle controller

## Battery control unit
"A simple automotive battery control unit (BCU) that calculates battery states, performs BMS housekeeping, and communicates with the domain controller."

I v�rt fall inkluderar det en seriell port f�r kommunikation med �vervakningsenheter som samlar in v�rden f�r batteristatus.

F�r enkelhetens skull �vervakar Battery Management System-kontrollern endast sp�nning.

# GPS unit.

"Collect vehicles current position and send the coordinates via serial port."


# Seriell kommunikation

## COM-portar. 

Seriella portar anv�nds alltj�mt i exempelvis automationstill�mpningar, i industriell automation f�r kommunikation med PLC (Programmable logic controller) eller undercentraler. Seriella portar �r ocks� vanliga i system f�r drift�vervakning.

## Null-modem emulator - Virtual Bridges

Man kan anv�nda sig av "HHD Software Virtual Serial Ports Tools", Free licence.

https://www.hhdsoftware.com


# Multiple startup projects 
To set multiple startup projects
In Solution Explorer, select the solution (the top node).
Choose the solution node's context (right-click) menu and then choose Properties. ...
Expand the Common Properties node, and choose Startup Project.
Choose the Multiple Startup Projects option and set the appropriate actions (Choose Start).
Apply changes to the solution properties.

## Uppgift:

Port-namn f�r simulator och kontroller ska vara konfigurerbara. 

* I .NET 8 anv�nder du vanligtvis appsettings.json-filen f�r att hantera konfigurationsinst�llningar.
	L�gg ett nytt item i varje-projekt, appsettings.json.

	JSON-formatet �r l�tt att arbeta med, och .NET 8 erbjuder en flexibel och kraftfull mekanism f�r att l�sa och hantera konfigurationer fr�n olika k�llor, inklusive JSON-filer, milj�variabler och anv�ndarspecifika inst�llningar.

* Installera NuGet-pakett f�r att kunna hantera Konfigurationer fr�n kod (ConfigurationBuilder).

* K�r om applikationerna med inst�llningar fr�n filen. Byt port mha emulator, konfigurera om portarna i json-filerna.

* K�r om.