using AutoMapper;

public class AutoMapping: Profile{
    public AutoMapping(){
        CreateMap<Movie, MovieDTO>();
        CreateMap<MovieDTO, Movie>();

        CreateMap<OrderDetail, OrderDetailDTO>();
        CreateMap<OrderDetailDTO, OrderDetail>();

        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();

        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();
    }
}