# ASP Core Custom filter error handling

Sample project showing different implementations of custom filters and checking how they handle exceptions.

* CustomAuthorisationFilterAttribute is an ActionFilterAttribute, the simplest implementation of a filter which does not allow dependencies injected
* CustomTypeFilterAttribute is TypeFilterAttribute, a more complex filter which allows dependency injection
* CustomApplicationFilter is a filter which uses an extension to add custom middleware to the request chain on demand. It allows dependencies but causes problems with exceptions which occur in the action, masking the stack trace and making it look like all exceptions occur in the middleware

Basic finding are that you should not use custom middleware as filters, since it causes side effects in exception handling in your application.
