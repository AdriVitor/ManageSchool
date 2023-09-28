namespace ManageSchool_API.Interfaces.IServices;

public interface IBaseInterfaceService<T>{
    public Task<T> Get(int id);
    public Task Add(T genericType);
    public Task Update(int id, T genericType);
    public Task Delete(int id);
}