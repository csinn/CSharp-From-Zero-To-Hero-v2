# Homework
This time, you will have to simulate a WebService which keeps track of your electric bill.

1. ~~Create a `PowerPlant` class. It has properties: `Location`, `ElectricityPrice`, `ProducedPowerPerDay`, `Name`.~~
2. ~~Create an `ElectricityProvider` class with a property `Name` and 3 methods:~~
    1. ~~`void Subscribe(PowerPlant plant)`~~
        - ~~subscribes to a single power plant. If powerplant is already subscribed, throws an exception.~~
    2. ~~`void Unsubscribe(PowerPlant plant)`~~
        - ~~unsubscribes from a subscribed power plant. If no powerplant is subscribed does nothing.~~
    3. ~~`decimal CalculatePrice(Address address)`~~
        ~~- use some arbitrary formula to calculate the price the provider will charge for elecrticity. `Location` should be a factor.~~
3. ~~Create a `Location` class with properties: `X`, `Y`, `Z`.~~
4. ~~Create an `Address` class with properties: `Country`, `City`, `Street`, `HouseNumber` and `Location`.~~
5. ~~Create an `ElectricProviderPicker`. It has:~~
    1. ~~A list of `ElectricProvider`s~~
    2. ~~A method `FindCheapest` which returns the best (cheapest) `ElectricProvider` for an address.~~
6. ~~Have a controller endpoint to get the `name` and `price` of the best `ElectricityProvider`.~~