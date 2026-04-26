import type { InputHTMLAttributes } from "react";
import type { UseFormRegister } from "react-hook-form";

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  field: string;
  register: UseFormRegister<any>;
}

export default function Input({ 
  field,
  register,
  ...children
}: Props) {
  return (
    <input {...register(field)} className="my-2 py-2 px-2 rounded-lg w-full bg-neutral-700 text-white" {...children} >
    </input>
  )
}
