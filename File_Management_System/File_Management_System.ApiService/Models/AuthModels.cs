namespace File_Management_System.ApiService.Models;

public record RegisterRequest(string UserName, string Email, string Password);
public record LoginRequest(string UserName, string Password);
