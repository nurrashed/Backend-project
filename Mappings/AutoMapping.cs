using AutoMapper;

public class AutoMapping: Profile{
    public AutoMapping(){
        CreateMap<Film, FilmDTO>();
        CreateMap<FilmDTO, Film>();

        CreateMap<OrderDetail, OrderDetailDTO>();
        CreateMap<OrderDetailDTO, OrderDetail>();

        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();

        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();
    }
}