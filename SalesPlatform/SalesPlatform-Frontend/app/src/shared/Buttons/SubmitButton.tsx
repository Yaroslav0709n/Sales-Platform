import React from 'react';
import {
    Button
} from './SubmitButton.element'

interface ButtonProps{
    onClick: (e: React.MouseEvent<HTMLButtonElement>) => void;
    type: "button" | "submit" | "reset" | undefined;
    children: React.ReactNode;
    className: string;
} 

const SubmitButton: React.FC<ButtonProps> = ({onClick, type, children, className}) => {
    return(
        <Button
            type={type}
            onClick={onClick}
            className={className}
        >
            {children}
        </Button>
    );
}

export default SubmitButton;