import { AppWrapper } from "../components/common/PageMeta";
import AppProviders from "./providers/AppProviders";
import { AppRouter } from "./router";

export default function App() {
  return (
    <AppProviders>
      <AppWrapper>
        <AppRouter />
      </AppWrapper>
    </AppProviders>
  );
}
