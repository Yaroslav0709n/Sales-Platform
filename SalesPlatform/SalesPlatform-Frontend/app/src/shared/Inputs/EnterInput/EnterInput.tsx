import React from 'react';
import {
    Input
} from './EnterInput.element'

interface InputProps{
    onChange: React.ChangeEventHandler<HTMLInputElement>;
    value: string | number | readonly string[] | undefined;
    type: React.HTMLInputTypeAttribute | undefined;
}


const EnterInput: React.FC<InputProps> = ({onChange, value, type}) => {
    return(
        <Input
            value={value}
            type={type}
            onChange={onChange}
        />
    );
}

export default EnterInput;