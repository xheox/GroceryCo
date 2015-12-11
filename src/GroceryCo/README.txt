################  Solution Structure ########################## 
Projects: 
- SharedObjects :  holds the shared objects between several projects
This avoids having cyclic references.
(most of the base classes and interfaces of the project are here)
- Services : The actual implementations of the services (checkout, configuration and discount calculation)
- Data :  DataLayer for persistence purpose.
- Logging : common project for logging purpose to avoid putting a logger for each project. 
- DiscountRules :  here are the implementations of different types of discounts  like : 

buy x units discount y %, 
buy x units get free y units, 
buy product x get product y, 
buy x$ get discount y%. 

All discount rules implement IDiscountRule to enable ease of extensions (through Injection or deployemnts as plugins)
=> Any new IDiscountRule will be applied according the configurations handed by the ConfigurationService 

- Presentation : here is the GUI/View layer (web, mobile, desktop app ....)
- For each layer we use a test project to run unit tests (or TDD) + 
a performance test project to have performance counters of the application and get info about the resources used 
################  Main Ideas of the solution ########################## 
 

- Single responsibility :  a service for each responsibility : (checkout, discount , configurations)
- loose coupling by using interfaces and absctract classes (to enable DI)


########################################  Execution ########################

1- The checkout service is called by the application
2- It gets the configurations (through the DiscountConfigurationService)  and the list of DicountRules available (through DiscountService)
3- ApplyDiscount After validation of both configurations & DicountRules (in case we want to have business rules how to enable Discounts and so on)
4- Combine the CartItem List with the List of DiscountIem in a single List (ViewModel) and update the Total and the discount amounts for each CartItem 
5- hand the result to the UI for display (and a printing service may be used also) 