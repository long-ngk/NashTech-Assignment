import React from 'react';


const ButtonIcon = ({ children, disable, onClick, className }) => {
    const style = disable ? 'disable' : 'pointer';

    const handleClick = (e) => {
        e.stopPropagation();

        if (disable) return;

        if (onClick) onClick();
    }

    return (
        <div onClick={handleClick} className={`${style} ${className}`}>
            {children}
        </div>
    );
};

export default ButtonIcon;
