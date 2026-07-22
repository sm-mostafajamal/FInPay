import { PencilIcon } from "../../assets/icons";
import { Module } from "../../components/layout/Sidebar/types";

export const loanModule : Module = {
    icon: <PencilIcon />,
    name: "Loan",
    subModules: [
        { 
            name: "Emi Calculator", 
            path: "calculate-emi", 
        }
    ]
}