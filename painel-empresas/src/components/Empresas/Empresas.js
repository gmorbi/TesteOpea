import React, { useState, useEffect } from 'react';
import empresaService from '../../services/empresaService';
import Modal from '../Modal';

const Empresas = () => {
  const [empresas, setEmpresas] = useState([]);
  const [novaEmpresa, setNovaEmpresa] = useState({ nome: '', porte: 'Pequena' });
  const [editandoEmpresa, setEditandoEmpresa] = useState(null);
  const [exibindoModalAdicionar, setExibindoModalAdicionar] = useState(false);
  const [exibindoModalEditar, setExibindoModalEditar] = useState(false);
  const [carregandoEmpresas, setCarregandoEmpresas] = useState(true);

  useEffect(() => {
    const fetchEmpresas = async () => {
      try {
        const empresasData = await empresaService.getAllEmpresas();
        setEmpresas(empresasData);
      } catch (error) {
        console.error('Erro ao buscar empresas:', error);
      } finally {
        setCarregandoEmpresas(false); // Indica que as empresas foram carregadas
      }
    };
    fetchEmpresas();
  }, []);

  const handleDeleteEmpresa = async (id) => {
    try {
      await empresaService.deleteEmpresa(id);
      setEmpresas(empresas.filter(emp => emp.id !== id));
    } catch (error) {
      console.error('Erro ao excluir empresa:', error);
    }
  };

  const handleEditEmpresa = (empresa) => {
    setEditandoEmpresa({ ...empresa });
    setExibindoModalEditar(true);
  };

  const handleSaveEditEmpresa = async () => {
    try {
      await empresaService.updateEmpresa(editandoEmpresa.id, editandoEmpresa);
      setEmpresas(empresas.map(emp => (emp.id === editandoEmpresa.id ? editandoEmpresa : emp)));
      setEditandoEmpresa(null);
      setExibindoModalEditar(false);
    } catch (error) {
      console.error('Erro ao salvar edição:', error);
    }
  };

  const handleCreateEmpresa = async () => {
    try {
      const novaEmpresaCriada = await empresaService.createEmpresa(novaEmpresa);
      setEmpresas([...empresas, novaEmpresaCriada]);
      setNovaEmpresa({ nome: '', porte: 'Pequena' });
      setExibindoModalAdicionar(false);
    } catch (error) {
      console.error('Erro ao adicionar empresa:', error);
    }
  };

  return (
    <div>
      <h1>Lista de Empresas</h1>
      <div style={{ marginBottom: '20px' }}>
        <button onClick={() => setExibindoModalAdicionar(true)}>Adicionar Empresa</button>
      </div>
      {carregandoEmpresas ? (
        <p>Carregando empresas...</p>
      ) : (
        <ul>
          {empresas.map((empresa) => (
            <li key={empresa.id}>
              <div style={{ marginBottom: '10px' }}>
                <strong>Nome: </strong>{empresa.nome}
                <br />
                <strong>Porte: </strong>{empresa.porte}
              </div>
              <button onClick={() => handleEditEmpresa(empresa)}>Editar</button>
              <button onClick={() => handleDeleteEmpresa(empresa.id)}>Excluir</button>
            </li>
          ))}
        </ul>
      )}
      {exibindoModalAdicionar && (
        <Modal onClose={() => setExibindoModalAdicionar(false)}>
          <h2>Adicionar Nova Empresa</h2>
          <input
            type="text"
            placeholder="Nome da empresa"
            value={novaEmpresa.nome}
            onChange={(e) => setNovaEmpresa({ ...novaEmpresa, nome: e.target.value })}
          />
          <select
            value={novaEmpresa.porte}
            onChange={(e) => setNovaEmpresa({ ...novaEmpresa, porte: e.target.value })}
          >
            <option value="Pequena">Pequena</option>
            <option value="Media">Média</option>
            <option value="Grande">Grande</option>
          </select>
          <button onClick={() => handleCreateEmpresa()}>Adicionar Nova Empresa</button>
        </Modal>
      )}
      {exibindoModalEditar && (
        <Modal onClose={() => setExibindoModalEditar(false)}>
          <h2>Editar Empresa</h2>
          <input
            type="text"
            value={editandoEmpresa.nome}
            onChange={(e) => setEditandoEmpresa({ ...editandoEmpresa, nome: e.target.value })}
          />
          <select
            value={editandoEmpresa.porte}
            onChange={(e) => setEditandoEmpresa({ ...editandoEmpresa, porte: e.target.value })}
          >
            <option value="Pequena">Pequena</option>
            <option value="Media">Média</option>
            <option value="Grande">Grande</option>
          </select>
          <button onClick={() => handleSaveEditEmpresa()}>Salvar</button>
        </Modal>
      )}
    </div>
  );
};

export default Empresas;
