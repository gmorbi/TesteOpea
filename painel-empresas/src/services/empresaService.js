import axios from 'axios';
import authService from '../utils/authService';

const empresaService = {
    async getAllEmpresas() {
        try {
            const token = await authService.authenticate();
            const response = await axios.get('https://localhost:7262/api/v1/Empresas', {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            return response.data;
        }
        catch (error) {
            console.error('Erro ao buscar empresa: ', error);
        }
    },

    async getEmpresaById(id) {
        try {
            const token = await authService.authenticate();
            const response = await axios.get(`https://localhost:7262/api/v1/Empresas/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            return response.data;
        } catch (error) {
            console.error(`Erro ao buscar empresa com ID ${id}:`, error);
            throw error;
        }
    },

    async createEmpresa(empresaData) {
        try {
            const token = await authService.authenticate();
            const response = await axios.post('https://localhost:7262/api/v1/Empresas', empresaData, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            return response.data;
        } catch (error) {
            console.error('Erro ao criar empresa:', error);
            throw error;
        }
    },

    async updateEmpresa(id, empresaData) {
        try {
            const token = await authService.authenticate();
            const response = await axios.put(`https://localhost:7262/api/v1/Empresas/${id}`, empresaData, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            return response.data;
        } catch (error) {
            console.error(`Erro ao atualizar empresa com ID ${id}:`, error);
            throw error;
        }
    },

    async deleteEmpresa(id) {
        try {
            const token = await authService.authenticate();
            await axios.delete(`https://localhost:7262/api/v1/Empresas/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
        } catch (error) {
            console.error(`Erro ao excluir empresa com ID ${id}:`, error);
            throw error;
        }
    }
};

export default empresaService;
