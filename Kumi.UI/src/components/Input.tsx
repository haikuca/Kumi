import type { InputHTMLAttributes } from "react";
import type { UseFormRegister } from "react-hook-form";

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  label: string;
  field: string;
  register: UseFormRegister<any>;
}

export default function Input({ 
  label,
  field,
  register,
  ...children
}: Props) {
  return (
    <div>
      <label className="text-white" >{ label }</label>
      <input {...register(field)} className="mb-2 mt-1 py-2 px-2 rounded-lg w-full bg-neutral-700 text-white" {...children} ></input>
    </div>
    
  )
}
