import axios from 'axios';
import { jwtDecode } from 'jwt-decode';

const authService = {
  async authenticate() {

    // const token = localStorage.getItem('token');
    
    // if(token){
    //   const isTokenValid = this.authenticate.isTokenValid(token);
    //   if(isTokenValid){
    //     return token;
    //   }
    // }

    try {
      const response = await axios.post('https://localhost:7262/api/v1/OAuth/token', {
        grant_type: 'client_credentials',
        client_id: 'teste.api',
        client_secret: '2784B9E8-8D91-4E52-A678-D8C7C2073A2B'
      });
      const newToken = response.data.access_token;
      localStorage.setItem('token', newToken);
      return newToken;
    } catch (error) {
      console.error('Erro ao autenticar:', error);
      return false;
    }
  },
  
  isTokenValid(token) {
    if (!token) return false; // Se não houver token, retorna falso

    // Verifica se o token expirou
    const decodedToken = jwtDecode(token);
    const currentTime = Date.now() / 1000;
    if (decodedToken.exp < currentTime) {
      localStorage.removeItem('token'); // Remove o token expirado
      return false;
    }

    return true; // Se o token ainda é válido, retorna true
  }
};

export default authService;
