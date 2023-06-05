import React, { createContext } from 'react';

export const DiscountContext = createContext(0);

export const DiscountProvider = ({ initVal, children }) => {
    return (
        <DiscountContext.Provider value={initVal}>
            {children}
        </DiscountContext.Provider>
    )
};