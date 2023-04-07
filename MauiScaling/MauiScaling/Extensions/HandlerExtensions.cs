namespace MauiScaling.Extensions
{
    public static class HandlerExtensions
    {
        public static void RemoveHandler(this IMauiHandlersCollection handlers, Type implementationType)
        {
            var handler = handlers.FirstOrDefault(handler => handler.ImplementationType == implementationType);
            if (handler != null)
            {
                handlers.Remove(handler);
            }
        }

        public static void ReplaceHandler(this IMauiHandlersCollection handlers, Type viewType, Type newImplementationType, Type oldImplementationType)
        {
            handlers.RemoveHandler(oldImplementationType);
            handlers.AddHandler(viewType, newImplementationType);
        }
    }
}