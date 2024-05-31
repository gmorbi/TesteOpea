import React from 'react';

const Modal = ({ children, onClose }) => {
  return (
    <div className="modal-overlay">
      <div className="modal">
        <button className="modal-close" onClick={onClose}>Fechar</button>
        <div className="modal-content">{children}</div>
      </div>
    </div>
  );
};

export default Modal;
