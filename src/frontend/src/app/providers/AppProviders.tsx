import { PropsWithChildren } from 'react'
import { ThemeProvider } from './ThemeProvider'

const AppProviders = ({children} : PropsWithChildren) => {
  return (
    <ThemeProvider>
        {children}
    </ThemeProvider>
  )
}

export default AppProviders