namespace residential_complex.Exceptions;

public class NotFoundException(string modelName,int id) : Exception($"{modelName} with Id {id} not found.")
{
    
}