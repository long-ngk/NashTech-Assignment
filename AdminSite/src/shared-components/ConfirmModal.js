import React from "react";
import { Modal } from 'react-bootstrap';

const ConfirmModal = ({ title, isShow, onHide, children }) => {

    return (
        <Modal
            show={isShow}
            onHide={onHide}
            dialogClassName="modal-90w"
            aria-labelledby="login-modal"
        >
            <Modal.Header closeButton>
                <Modal.Title id="login-modal">
                    {title}
                </Modal.Title>
            </Modal.Header>

            <Modal.Body>
                {children}
            </Modal.Body>
        </Modal>
    );
};

export default ConfirmModal;
