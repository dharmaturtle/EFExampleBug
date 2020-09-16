CREATE TABLE public.alpha_beta_key (
    id integer NOT NULL,
    created timestamp with time zone DEFAULT timezone('utc'::text, now()) NOT NULL
);