## Refactoring initial list
- ConfigurationManager to use IOptions<PaymentServiceOptions>
- use of a factory to get main or backup instance of dataStore
- check for null account removed to before switch
- abstract class to handle payment validation instead of switch
- reuse accountDataStore on success
- DataStoreType should be enum

## Thinking behind code
### Configuration manager to IOptions
In a real-world code example, I would use the IOptions pattern for passing around configuration, rather than passing a full configuration manager object. This ensures Encapsulation by restricting access to data that it doesn't need.

### Use of a factory to get data store implementation
Removal of decision logic to select data store implementation and move to a factory. Moving to a factory allows the decision logic to be moved to the DI.

### Moving check for null
In the original switch statement, each case would check the account for null, meaning there was repeated code. My first thought was to simply move this out of each case to just above it and return false from there, but as I got more into the validation of the payment i decided to move into the validation, which means it’s in a centralised place, and the removal of repeated code.

### Abstract class to handle payment validation instead of switch
With the null check there was also a check for allowed payment schemes on the account, again moving this into the validation centralised it and allowed me to make it reusable. As the check for null and the payment schemes on account check were used on both it made sense to have these in an abstract class, and to build more specific implementations for each payment schemes on top of these. Additional I added the specification pattern to allow validation rule to be used across different validator implementations. This is in keeping with Single responsibility and Open-closed principles.

### Reuse accountDataStore on success
Adding the factory for the data store meant it could be reused within the result.Success condition, rather than having to use a second implementation.

### DataStoreType should be enum
I feel this is tidier and allows for more consise decision logic and less errors when writing code.

### Service code reduced
I always feel that a service is specifically for business logic, and that it orchestrates interactions with infrastructure. In this example it orchestrates; getting the relevant data store, gets the account from the data store, get the relevant validator, validates the request and the account, then it updates the account if successful. What’s important about this is that this is what the service is orchestrating, but it doesn’t care how it does any of it, whereas the initial code had the validation rules within it. Again this is an example of the Single Responsibility principle.

### Dependecy injection
I made the changes as if I would with DI. I have also added a DependencyInjectionExtensions.cs to show how the factories would work with the relevant keyed services, and the adding of the IOptions.

