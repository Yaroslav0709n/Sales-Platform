import React from 'react';
import {
    Input
} from './EnterInput.element'

interface InputProps{
    onChange: React.ChangeEventHandler<HTMLInputElement>;
    value: string | number | readonly string[] | undefined;
    type: React.HTMLInputTypeAttribute | undefined;
    className?: string;
}


const EnterInput: React.FC<InputProps> = ({onChange, value, type, className}) => {
    return(
        <Input
            value={value}
            type={type}
            onChange={onChange}
            className={className}
        />
    );
}

export default EnterInput;