export type SidebarContextType = {
  isExpanded: boolean;
  isMobileOpen: boolean;
  isHovered: boolean;
  activeItem: string | null;
  openSubmenu: string | null;
  toggleSidebar: () => void;
  toggleMobileSidebar: () => void;
  setIsHovered: (isHovered: boolean) => void;
  setActiveItem: (item: string | null) => void;
  toggleSubmenu: (item: string) => void;
};

export type Module = {
  icon: React.ReactNode;  
  name: string;
  subModules: { 
    name: string; 
    path: string; 
    new?: boolean 
  }[];
};

export type Sidebar = { 
  isExpanded: boolean,
  isHovered: boolean, 
  isMobileOpen: boolean
}

export type RenderSideMenuModules = {
  modules : Module[] ,
  menuType?: "main" | "others"
} & Sidebar;