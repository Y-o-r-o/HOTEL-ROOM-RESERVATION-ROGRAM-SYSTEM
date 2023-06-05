import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import Footer from '../../components/Footer/index';
import Header from '../../components/Header/index';
import Reservation from '../../components/Reservation/index';
import Search from '../../components/Search/index';
import { DiscountProvider } from '../../store/DiscountContext';
import { RoomProvider } from '../../store/RoomContext';
import { SearchProvider, useSearchValue } from '../../store/SearchContext';
import './style.scss';
import { Grid, GridColumn } from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css'


function BookingLayout({ children }) {

    const [discount, setDiscount] = useState(0);
    const path = useLocation().search;

    useEffect(() => {
        if (path) {
            const promo_code = path.match(/promo_code=\d{1,3}/ig);
            if (promo_code) {
                setDiscount(parseInt(promo_code[0].split("=")[1]));
            }
        }
    }, []);

    return (
        <DiscountProvider initVal={discount}>
            <SearchProvider>
                <RoomProvider>
                    <div className='app'>
                        <Header />
                        <Search />
                        <Grid columns={2} padded='horizontally'>
                            <Grid.Row>
                                <GridColumn width={4}/>
                                <Grid.Column width={6}>
                                    {children}
                                    </Grid.Column>
                                    <GridColumn width={1}/>
                                <Grid.Column width={5} floated='right'>
                                    <Grid>
                                        <Grid.Row />
                                        <Grid.Row />
                                        <Grid.Row />
                                        <Grid.Row>
                                            <Reservation />
                                        </Grid.Row>
                                    </Grid>
                                </Grid.Column>
                            </Grid.Row>
                        </Grid>
                        <Footer />
                    </div>
                </RoomProvider>
            </SearchProvider >
        </DiscountProvider>
    )
}

export default BookingLayout
